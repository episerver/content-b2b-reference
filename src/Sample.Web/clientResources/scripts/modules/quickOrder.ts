import axios from "axios";

const quickOrder = (): void => {
    const init = (): void => {
        const addToQuickorderForm = document.getElementById('quickorder_addToForm');
        if (addToQuickorderForm) {
            addToQuickorderForm.addEventListener("click", (e: MouseEvent) => {
                axios({
                    url: '/quickorderpage/addtoquickorder',
                    method: "POST",
                    data: {
                        productId: (document.getElementById('quickorder_ProductId') as HTMLInputElement)?.value ?? '',
                        qty: (document.getElementById('quickorder_Quantity') as HTMLInputElement)?.value ?? '1',
                        uom: (document.getElementById('quickorder_UOM') as HTMLSelectElement)?.selectedOptions[0]?.value ?? '',
                    },
                }).then(function (result) {
                    if (result.data) {
                        result.data.product.qtyOrdered = Number((document.getElementById('quickorder_Quantity') as HTMLInputElement)?.value ?? '1');
                        const uom = (document.getElementById('quickorder_UOM') as HTMLSelectElement)?.selectedOptions[0]?.value;
                        if (uom !== undefined) {
                            result.data.product.unitOfMeasure = uom;
                        }
                        addQuickOrderItem(result.data);
                        const addToCartElements = document.getElementsByClassName('quickorder_addToCart') as HTMLCollectionOf<HTMLElement>;
                        const arr = Array.from(addToCartElements);
                        arr.forEach(element => {
                            element.classList.remove('invisible');
                        });
                    }
                }).then(function (result) {
                    const removeFromFormElements = document.getElementsByClassName('quickorder_RemoveFromForm') as HTMLCollectionOf<HTMLElement>;
                    const removeArray = Array.from(removeFromFormElements);
                    removeArray.forEach(element => {
                        element.addEventListener("click", (e: MouseEvent) => {
                            removeQuickOrderItem(element.getAttribute('data-productId'))
                        });
                    });
                }).catch(function (e) {
                        console.log(e);
                    });
            });
        }

        const addToCartElements = document.getElementsByClassName('quickorder_addToCart') as HTMLCollectionOf<HTMLElement>;
        const arr = Array.from(addToCartElements);
        arr.forEach(element => {
            element.addEventListener("click", (e: MouseEvent) => {
                const data = window.Alpine.store('quickorderItems');
                axios({
                    url: '/quickorderpage/addtocart',
                    method: "POST",
                    data: data,
                }).then(function (result) {
                    if (result.data) {
                        window.location.href = result.data.url;
                    }
                }).catch(function (e) {
                    console.log(e);
                });
            });
        });
    };

    window.quickOrderInit = (): void => {
        const productElements = document.getElementsByClassName('quickorderAdd') as HTMLCollectionOf<HTMLElement>;
        const arr = Array.from(productElements);
        arr.forEach(element => {
            element.addEventListener("click", (e: MouseEvent) => {
                axios({
                    url: '/quickorderpage/selectproduct',
                    method: "POST",
                    data: {
                        productId: element.getAttribute('data-productId'),
                    },
                }).then(function (result) {
                    if (result.data) {
                        const uom = document.getElementById('quickorder_UOM') as HTMLSelectElement;
                        const uomContainer = document.getElementById('uomContainer');
                        const search = document.getElementById('quickorder_Search') as HTMLInputElement;
                        if (result.data.productUnitOfMeasures.length > 1) {
                            uom.options.length = 0;
                            for (let i = 0; i < result.data.productUnitOfMeasures.length; i++) {
                                let opt = document.createElement("option");
                                opt.value = result.data.productUnitOfMeasures[i].id;
                                opt.text = result.data.productUnitOfMeasures[i].description;
                                uom.add(opt, null);
                            }
                            uomContainer?.classList.remove("invisible");
                        }
                        else {
                            uomContainer?.classList.add("invisible");
                        }
                        search.value = result.data.shortDescription;
                        document.getElementById('quickorder_container')._x_dataStack[0].showResults = false;
                        (document.getElementById('quickorder_ProductId') as HTMLInputElement).value = result.data.id;
                    }
                }).catch(function (e) {
                    console.log(e);
                });
            });
        });
    };

    const addQuickOrderItem = (data:object): void => {
        let items = window.Alpine.store('quickorderItems');
        items.push(data);
        window.Alpine.store('quickorderItems', items);
    }

    const removeQuickOrderItem = (productId:string): void => {
        let items = window.Alpine.store('quickorderItems');
        for (let i = 0; i < items.length; i++) {
            if (items[i].product.id === productId) {
                items.splice(i, 1);
                if (items.length === 0) {
                    const addToCartElements = document.getElementsByClassName('quickorder_addToCart') as HTMLCollectionOf<HTMLElement>;
                    const arr = Array.from(addToCartElements);
                    arr.forEach(element => {
                        element.classList.add('invisible');
                    });
                    break;
                }
            }
        }
        window.Alpine.store('quickorderItems', items);
    }

    init();
};

export default quickOrder;
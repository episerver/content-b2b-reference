import axios from "axios";

const cart = (): void => {

    const init = (): void => {
        const cartQuantitylements = document.getElementsByClassName('actionChangeCartQuantity') as HTMLCollectionOf<HTMLElement>;
        Array.from(cartQuantitylements).forEach(element => {
            element.addEventListener("change", (e: Event) => {
                let qty = '1';
                const qtyElement = element as HTMLInputElement;
                if (qtyElement && qtyElement.value) {
                    qty = qtyElement.value;
                }
                const data = {
                    productId: element.getAttribute('data-productId'),
                    qty: qty,
                    cartLineId: element.getAttribute('data-cartLineId')
                };
                axios({
                    url: '/cartpage/updatecartquantity',
                    method: "POST",
                    data: data,
                }).then(function (result) {
                    if (result.data) {
                        window.location.href = window.location.href.replace('#', '');
                    }
                    else {

                    }
                }).catch(function (e) {
                    console.log(e);
                });
            });
        });

        const noteCartElements = document.getElementsByClassName('actionCartNotes') as HTMLCollectionOf<HTMLElement>;
        Array.from(noteCartElements).forEach(element => {
            element.addEventListener("change", (e: Event) => {
                let text = '';
                const textElement = element as HTMLInputElement;
                if (textElement && textElement.value) {
                    text = textElement.value;
                }
                const data = {
                    itemNote: text,
                    cartLineId: element.getAttribute('data-cartLineId')
                };
                axios({
                    url: '/cartpage/updatecartnote',
                    method: "POST",
                    data: data,
                }).then(function (result) {
                    if (result.data) {
                        window.location.href = window.location.href.replace('#', '');
                    }
                    else {

                    }
                }).catch(function (e) {
                    console.log(e);
                });
            });
        });

        const wishlistElements = document.getElementsByClassName('actionAddToWishList') as HTMLCollectionOf<HTMLElement>;
        Array.from(wishlistElements).forEach(element => {
            element.addEventListener("click", (e: Event) => {
                const data = {
                    productId: element.getAttribute('data-productId'),
                    unitOfMeasure: element.getAttribute('data-unitOfMeasure')
                };
                axios({
                    url: '/wishlistpage/addtodefaultwishList',
                    method: "POST",
                    data: data,
                }).then(function (result) {
                    if (result.data) {
                        window.location.href = window.location.href.replace('#', '');
                    }
                    else {

                    }
                }).catch(function (e) {
                    console.log(e);
                });
            });
        });

        const deleteElements = document.getElementsByClassName('actionRemoveFromCart') as HTMLCollectionOf<HTMLElement>;
        Array.from(deleteElements).forEach(element => {
            element.addEventListener("click", (e: Event) => {
                const data = {
                    productId: element.getAttribute('data-productId'),
                    qty: "0",
                    cartLineId: element.getAttribute('data-cartLineId')
                };
                axios({
                    url: '/cartpage/updatecartquantity',
                    method: "POST",
                    data: data,
                }).then(function (result) {
                    if (result.data) {
                        window.location.href = window.location.href.replace('#', '');
                    }
                    else {

                    }
                }).catch(function (e) {
                    console.log(e);
                });
            });
        });

        const warehouseElements = document.getElementsByClassName('actionChooseWarehouse') as HTMLCollectionOf<HTMLElement>;
        Array.from(warehouseElements).forEach(element => {
            element.addEventListener("click", (e: Event) => {
                const data = {
                    warehouseId: element.getAttribute('data-warehouseId'),
                };
                axios({
                    url: '/cartpage/updatewarehouseid',
                    method: "POST",
                    data: data,
                }).then(function (result) {
                    if (result.data) {
                        window.location.href = window.location.href.replace('#', '');
                    }
                    else {

                    }
                }).catch(function (e) {
                    console.log(e);
                });
            });
        });

        const shipToElement = document.querySelector('.actionShipTo');
        if (shipToElement) {
            shipToElement.addEventListener("click", (e: Event) => {
                const data = {
                    fullfilmentType: 'Ship',
                };
                axios({
                    url: '/cartpage/updatefulfillmentmethod',
                    method: "POST",
                    data: data,
                }).then(function (result) {
                    if (result.data) {
                        window.location.href = window.location.href.replace('#', '');
                    }
                    else {

                    }
                }).catch(function (e) {
                    console.log(e);
                });
            });
        }
    };

    init();
};

export default cart;
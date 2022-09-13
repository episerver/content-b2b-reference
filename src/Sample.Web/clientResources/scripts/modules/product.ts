import axios from "axios";
import traitOptions from '../models/traitOptions';

const product = (): void => {

    const init = (): void => {
        const filterElements = document.getElementsByClassName('actionAddToCart') as HTMLCollectionOf<HTMLElement>;
        const arr = Array.from(filterElements);
        arr.forEach(element => {
            element.addEventListener("click", (e: MouseEvent) => {
                let qty = '1';
                const qtyElement = document.getElementById('productQuantity') as HTMLInputElement;
                if (qtyElement && qtyElement.value) {
                    qty = qtyElement.value;
                }
                const data = {
                    productId: element.getAttribute('data-productId'),
                    qty: qty,
                    unitOfMeasure: element.getAttribute('data-unitOfMeasure'),
                    options: getSelectedOptions()
                };
                axios({
                    url: '/cartpage/addtocart',
                    method: "POST",
                    data: data,
                }).then(function (result) {
                    let messageLabel = document.getElementById('cartToastMessage');
                    if (result.data && messageLabel) {
                        messageLabel.innerText = 'Added ' + qty.toString() + ' item(s) to your cart.';
                        let miniCartNumber = document.getElementById('miniCartNumber');
                        if (miniCartNumber) {
                            miniCartNumber.innerText = miniCartNumber.innerText ? (Number(miniCartNumber.innerText) + 1).toString() : '1';
                        }
                    }
                    else {
                        if (messageLabel) {
                            messageLabel.innerText = 'Problem adding to your cart.';
                            let toast = document.getElementById('cartToast');
                            if (toast) {
                                toast.classList.remove('bg-green-500');
                                toast.classList.add('bg-red-500');
                            }
                        }
                        
                    }
                    document.getElementById('addToCartToast')?.classList.remove("invisible");
                }).catch(function (e) {
                    console.log(e);
                });
            });
        });

        document.getElementById('closeCartToast')?.addEventListener("click", (e: MouseEvent) => {
            document.getElementById('addToCartToast')?.classList.add("invisible");
        });
    };

    const getSelectedOptions = (): Array<traitOptions> => {
        const variants = document.getElementsByClassName('actionChangeVariant') as HTMLCollectionOf<HTMLElement>;
        const options: traitOptions[] = [];
        for (var i = 0; i < variants.length; i++) {
            const select = variants[i] as HTMLSelectElement;
            options.push({
                value: select.options[select.selectedIndex].value,
                traitId: select.getAttribute('data-traitId')
            })
        }
        return options;
    }

    init();
};

export default product;
import axios from "axios";

const header = (): void => {

    const init = (): void => {
        const changeCustomer = document.getElementById('header_UpdateCustomer');
        if (changeCustomer) {
            changeCustomer.addEventListener("click", (e: MouseEvent) => {
                const billTo = (document.getElementById('header_BillTo') as HTMLSelectElement)?.selectedOptions[0].value;
                const shipTo = (document.getElementById('header_ShipTo') as HTMLSelectElement)?.selectedOptions[0].value;
                const fulfillmentMethod = (document.querySelector('input[name=fulfillmentMethod]:checked') as HTMLInputElement).value;
                const warehouse = (document.getElementById('header_Warehouse') as HTMLSelectElement)?.selectedOptions[0].value;
                const data = {
                    billTo: billTo,
                    shipTo: shipTo,
                    fulfillmentMethod: fulfillmentMethod,
                    warehouse: warehouse,
                };
                axios({
                    url: '/header/changecustomer',
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

        const mobileChangeCustomer = document.getElementById('header_mobile_UpdateCustomer');
        if (mobileChangeCustomer) {
            mobileChangeCustomer.addEventListener("click", (e: MouseEvent) => {
                const billTo = (document.getElementById('header_mobile_BillTo') as HTMLSelectElement)?.selectedOptions[0].value;
                const shipTo = (document.getElementById('header_mobile_ShipTo') as HTMLSelectElement)?.selectedOptions[0].value;
                const fulfillmentMethod = (document.querySelector('input[name=mobile_FulfillmentMethod]:checked') as HTMLInputElement).value;
                const warehouse = (document.getElementById('header_mobile_Warehouse') as HTMLSelectElement)?.selectedOptions[0].value;
                const data = {
                    billTo: billTo,
                    shipTo: shipTo,
                    fulfillmentMethod: fulfillmentMethod,
                    warehouse: warehouse,
                };
                axios({
                    url: '/header/changecustomer',
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

        const currencyElements = document.getElementsByClassName('changeCurrency') as HTMLCollectionOf<HTMLElement>;
        const arr = Array.from(currencyElements);
        arr.forEach(element => {
            element.addEventListener("change", (e: Event) => {
                const currency = e.target as HTMLSelectElement;
                axios({
                    url: '/header/changecurrency?currencyId=' + currency.selectedOptions[0].value,
                    method: "POST",
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

        const languageElements = document.getElementsByClassName('changeLanguage') as HTMLCollectionOf<HTMLElement>;
        const languageArray = Array.from(languageElements);
        languageArray.forEach(element => {
            element.addEventListener("change", (e: Event) => {
                const language = e.target as HTMLSelectElement;
                axios({
                    url: '/header/changelanguage?languageId=' + language.selectedOptions[0].value,
                    method: "POST",
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

        document.getElementById('layout_ToastClose')?.addEventListener("click", (e: MouseEvent) => {
            document.getElementById('layout_Toast')?.classList.add("invisible");
        });
    };

    init();
};

export default header;
import axios from "axios";

const checkout = (): void => {

    const init = (): void => {

        const billToElements = document.getElementsByClassName('actionSelectBillTo') as HTMLCollectionOf<HTMLElement>;
        Array.from(billToElements).forEach(element => {
            element.addEventListener("click", (e: Event) => {
                const data = {
                    addressId: element.getAttribute('data-addressId'),
                };
                axios({
                    url: '/checkoutpage/updatecartquantity',
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
        
        const shipToElements = document.getElementsByClassName('actionSelectShipTo') as HTMLCollectionOf<HTMLElement>;
        Array.from(shipToElements).forEach(element => {
            element.addEventListener("click", (e: Event) => {
                const data = {
                    addressId: element.getAttribute('data-addressId'),
                };
                axios({
                    url: '/checkoutpage/updateshipTo',
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

        const submitAddress = document.querySelector('.actionEditAddress');
        if (submitAddress) {
            submitAddress.addEventListener("click", (e: Event) => {
                const isNew = ((document.getElementById('addressIsNew') as HTMLInputElement)?.value ?? 'false') === 'true';
                const data = getAddressData(isNew);
                const url = document.getElementById('addressPostUrl') as HTMLInputElement;
                axios({
                    url: url?.value ?? '/checkoutpage/updateshipTo',
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

        const notes = document.querySelector('.actionChechoutNotes') as HTMLInputElement;
        if (notes) {
            notes.addEventListener("change", (e: Event) => {
                const data = {
                    itemNote: notes.value
                };
                axios({
                    url: '/checkoutpage/updateNotes',
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

        window.CreateShipTo = (): void => {
            clearAddress();
            const url = document.getElementById('addressPostUrl') as HTMLInputElement;
            if (url) {
                url.value = '/checkoutpage/createShipTo';
            }
            const isNew = document.getElementById('addressIsNew') as HTMLInputElement;
            if (isNew) {
                isNew.value = 'true';
            }
        };

        const submitOrder = document.getElementsByClassName('actionSubmitOrder') as HTMLCollectionOf<HTMLElement>;
        Array.from(submitOrder).forEach(element => {
            element.addEventListener("click", (e: Event) => {
                window.tokenFrame.tokenize();
            });
        });

        window.submitCart = (token: string, cardType:string): void => {
            const data = getReviewAndSubmitData(token, cardType);
            axios({
                url: '/checkoutpage/submitorder',
                method: "POST",
                data: data,
            }).then(function (result) {
                if (result.data && result.data.success) {
                    window.location.href = result.data.url;
                }
                else {

                }
            }).catch(function (e) {
                console.log(e);
            });
        };

    };

    const clearAddress = (): void => {
        const label = document.getElementById('editAddress_Label') as HTMLInputElement;
        if (label) {
            label.value = '';
        }

        const isDefault = document.getElementById('editAddr3ss_IsDefault') as HTMLInputElement;
        if (isDefault) {
            isDefault.checked = false;
        }

        const companyName = document.getElementById('editAddress_CompanyName') as HTMLInputElement;
        if (companyName) {
            companyName.value = '';
        }

        const attention = document.getElementById('editAddress_Attention') as HTMLInputElement;
        if (attention) {
            attention.value = '';
        }

        const address1 = document.getElementById('editAddress_Address1') as HTMLInputElement;
        if (address1) {
            address1.value = '';
        }

        const address2 = document.getElementById('editAddress_Address2') as HTMLInputElement;
        if (address2) {
            address2.value = '';
        }

        const countries = document.getElementById('editAddress_Countries') as HTMLSelectElement;
        if (countries) {
            countries.selectedIndex = 0;
        }

        const postalCode = document.getElementById('editAddress_PostalCode') as HTMLInputElement;
        if (postalCode) {
            postalCode.value = '';
        }

        const city = document.getElementById('editAddress_City') as HTMLInputElement;
        if (city) {
            city.value = '';
        }

        const email = document.getElementById('editAddress_Email') as HTMLInputElement;
        if (email) {
            email.value = '';
        }

        const phone = document.getElementById('editAddress_Phone') as HTMLInputElement;
        if (phone) {
            phone.value = '';
        }
    }; 

    const getAddressData = (isNew: boolean): object => {
        return {
            isNew: isNew,
            oneTimeAdress: !isNew,
            label: (document.getElementById('editAddress_Label') as HTMLInputElement)?.value ?? '',
            isDefault: (document.getElementById('editAddr3ss_IsDefault') as HTMLInputElement)?.checked ?? false,
            companyName: (document.getElementById('editAddress_CompanyName') as HTMLInputElement)?.value ?? '',
            attention: (document.getElementById('editAddress_Attention') as HTMLInputElement)?.value ?? '',
            address1: (document.getElementById('editAddress_Address1') as HTMLInputElement)?.value ?? '',
            address2: (document.getElementById('editAddress_Address2') as HTMLInputElement)?.value ?? '',
            countryId: (document.getElementById('editAddress_Countries') as HTMLSelectElement)?.selectedOptions[0].value ?? '',
            stateId: (document.getElementById('editAddress_Regions') as HTMLSelectElement)?.selectedOptions[0].value ?? '',
            postalCode: (document.getElementById('editAddress_PostalCode') as HTMLInputElement)?.value ?? '',
            city: (document.getElementById('editAddress_City') as HTMLInputElement)?.value ?? '',
            email: (document.getElementById('editAddress_Email') as HTMLInputElement)?.value ?? '',
            phone: (document.getElementById('editAddress_Phone') as HTMLInputElement)?.value ?? '',
        };
       
    }; 

    const getReviewAndSubmitData = (token:string, cardType:string): object => {
        return {
            carrierId: (document.getElementById('checkout_Carriers') as HTMLSelectElement)?.selectedOptions[0].value ?? '',
            serviceId: (document.getElementById('checkout_Services') as HTMLSelectElement)?.selectedOptions[0].value ?? '',
            deliveryDate: (document.getElementById('checkout_DeliveryDate') as HTMLInputElement)?.value ?? '',
            paymentMethodId: (document.getElementById('checkout_PaymentMethods') as HTMLSelectElement)?.selectedOptions[0].value ?? '',
            poNumber: (document.getElementById('checkout_PONumber') as HTMLInputElement)?.value ?? '',
            saveCard: (document.getElementById('checkout_SaveCard') as HTMLInputElement)?.checked ?? false,
            nameOnCard: (document.getElementById('checkout_NameOnCard') as HTMLInputElement)?.value ?? '',
            expirationDate: (document.getElementById('checkout_ExpirationDate') as HTMLInputElement)?.value ?? '',
            useBillingAddress: (document.getElementById('checkout_UseBillingAddress') as HTMLInputElement)?.checked ?? false,
            address1: (document.getElementById('ccAddress_Address1') as HTMLInputElement)?.value ?? '',
            countryId: (document.getElementById('ccAddress_Countries') as HTMLSelectElement)?.selectedOptions[0].value ?? '',
            regionId: (document.getElementById('ccAddress_Regions') as HTMLSelectElement)?.selectedOptions[0].value ?? '',
            postalCode: (document.getElementById('ccAddress_PostalCode') as HTMLInputElement)?.value ?? '',
            city: (document.getElementById('ccAddress_City') as HTMLInputElement)?.value ?? '',
            cardToken: token,
            cardType: cardType,
        };

    }; 

    init();
};

export default checkout;
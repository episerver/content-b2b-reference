import axios from "axios";

const addresses = (): void => {

    const init = (): void => {
        const billTo = document.getElementById('addresses_BillTo');
        if (billTo ) {
            billTo.addEventListener("change", (e: Event) => {
                const data = getSearchData();
                axios({
                    url: '/addressespage/searchaddresses?billToId=' + e.target?.value ?? '',
                    method: "POST",
                    data: data,
                }).then(function (result) {
                    renderTable(result.data);
                }).catch(function (e) {
                    console.log(e);
                });
            });
        }

        const editBilling = document.getElementById('editAddress_Save');
        if (editBilling) {
            editBilling.addEventListener("click", (e: MouseEvent) => {
                const data = getAddressData(editBilling.getAttribute('data-billToId'), editBilling.getAttribute('data-shipToId'));
                axios({
                    url: '/addressespage/saveaddrress',
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
        }

        const filterElements = document.getElementsByClassName('addressesFilter') as HTMLCollectionOf<HTMLElement>;
        const filterArray = Array.from(filterElements);
        filterArray.forEach(element => {
            element.addEventListener("change", (e: Event) => {
                const data = element.getAttribute('data') ?? '';
                if (element.classList.contains('addresesPaginate')) {
                    paginate(data);
                }

                if (element.classList.contains('addressesSearch')) {
                    filter();
                }

               
            });
        });
    };

    const paginate = (page: string): void => {
        var inputElement = <HTMLInputElement>document.getElementById('addresses_Page');
        if (!inputElement) {
            return;
        }
        inputElement.value = page;
        search();
    };

    const filter = (): void => {
        search();
    };

    const search = (): void => {
        axios({
            url: '/addressespage/searchaddresses?billToId=' + (document.getElementById('addresses_BillTo') as HTMLSelectElement).selectedOptions[0].value,
            method: "POST",
            data: getSearchData(),
        }).then(function (result) {
            renderTable(result.data);
        }).catch(function (e) {
            console.log(e);
        });
    }


    const getSearchData = (): object => {
        let page = 1;
        if (document.getElementById('addresses_Page') as HTMLInputElement != null && (document.getElementById('addresses_Page') as HTMLInputElement).value !== '') {
            page = Number((document.getElementById('addresses_Page') as HTMLInputElement).value);
        }
        let pageSize = 25;
        if (document.getElementById('addresses_PageSize') as HTMLInputElement != null && (document.getElementById('addresses_PageSize') as HTMLInputElement).value !== '') {
            pageSize = Number((document.getElementById('addresses_PageSize') as HTMLInputElement)?.value ?? '25');
        }
        
        return {
            filter: (document.getElementById('addresses_search') as HTMLInputElement)?.value ?? '',
            page: page,
            pageSize: pageSize,
        };
    }; 

    const getAddressData = (billToId:string | null, shipToId:string | null): object => {
        return {
            label: (document.getElementById('editAddress_Label') as HTMLInputElement)?.value ?? '',
            isDefault: (document.getElementById('editAddress_IsDefault') as HTMLInputElement)?.checked ?? false,
            companyName: (document.getElementById('editAddress_CompanyName') as HTMLInputElement)?.value ?? '',
            attention: (document.getElementById('editAddress_Attention') as HTMLInputElement)?.value ?? '',
            address1: (document.getElementById('editAddress_Address1') as HTMLInputElement)?.value ?? '',
            address2: (document.getElementById('editAddress_Address2') as HTMLInputElement)?.value ?? '',
            city: (document.getElementById('editAddress_City') as HTMLInputElement)?.value ?? '',
            postalCode: (document.getElementById('editAddress_PostalCode') as HTMLInputElement)?.value ?? '',
            email: (document.getElementById('editAddress_Email') as HTMLInputElement)?.value ?? '',
            phone: (document.getElementById('editAddress_Phone') as HTMLInputElement)?.value ?? '',
            country: (document.getElementById('editAddress_Countries') as HTMLSelectElement)?.selectedOptions[0]?.value ?? '',
            state: (document.getElementById('editAddress_Regions') as HTMLSelectElement)?.selectedOptions[0]?.value ?? '',
            billToId: billToId,
            shipToId: shipToId
        };
    }; 

    const renderTable = (data: any): void => {
        let resultHtml = new DOMParser().parseFromString(data, "text/html");
        if (document.getElementById('addressesTable') != null && resultHtml.getElementById('addressesTable') != null) {
            document.getElementById('addressesTable').outerHTML = resultHtml.getElementById('addressesTable').outerHTML;
        }
        //document.getElementById('orderHistory_TotalOrders').innerText = (document.getElementById('orderHistory_TotalCount') as HTMLInputElement).value + ' orders ';
        init();
    };

    init();
};

export default addresses;
import axios from "axios";

const orderHistory = (): void => {
    let sort: string = '';
    let sortDirection = '';
    const init = (): void => {
        const sortElements = document.getElementsByClassName('orderHistorySort') as HTMLCollectionOf<HTMLElement>;
        const arr = Array.from(sortElements);
        arr.forEach(element => {
            element.addEventListener("click", (e: MouseEvent) => {
                const previousSort = sort;
                sort = element.getAttribute('data-sort') ?? '';
                
                if (previousSort === sort) {
                    if (sortDirection === 'DESC') {
                        (document.getElementById('filter_Sort') as HTMLInputElement).value = sort + '';
                        sortDirection = '';
                    }
                    else {
                        (document.getElementById('filter_Sort') as HTMLInputElement).value = sort + ' DESC';
                        sortDirection = 'DESC';
                    }
                }
                else {
                    (document.getElementById('filter_Sort') as HTMLInputElement).value = sort + '';
                }
                const data = getSearchData();
                axios({
                    url: '/orderhistorypage/searchorder',
                    method: "POST",
                    data: data,
                }).then(function (result) {
                    renderTable(result.data);
                }).catch(function (e) {
                    console.log(e);
                });
            });
        });

        const filterElements = document.getElementsByClassName('actionHistorySort') as HTMLCollectionOf<HTMLElement>;
        const filterArray = Array.from(filterElements);
        filterArray.forEach(element => {
            element.addEventListener("change", (e: Event) => {
                const data = getSearchData();
                axios({
                    url: '/orderhistorypage/searchorder',
                    method: "POST",
                    data: data,
                }).then(function (result) {
                    renderTable(result.data);
                }).catch(function (e) {
                    console.log(e);
                });
            });
        });
    };

    const getSearchData = (): object => {
        let total = 1;
        if (document.getElementById('filter_OrderAmount') as HTMLInputElement != null) {
            total = Number((document.getElementById('filter_OrderAmount') as HTMLInputElement).value);
        }
        let fromDate = null;
        if (document.getElementById('filter_FromDate') as HTMLInputElement != null && (document.getElementById('filter_FromDate') as HTMLInputElement).value !== '') {
            fromDate = (document.getElementById('filter_FromDate') as HTMLInputElement).value;
        }
        let toDate = null;
        if (document.getElementById('filter_ToDate') as HTMLInputElement != null && (document.getElementById('filter_ToDate') as HTMLInputElement).value !== '') {
            toDate = (document.getElementById('filter_ToDate') as HTMLInputElement).value;
        }
        let status:string[] | null = null;
        if (document.getElementById('filter_Status') as HTMLSelectElement != null && (document.getElementById('filter_Status') as HTMLSelectElement)?.selectedOptions[0].value !== '') {
            status = (document.getElementById('filter_Status') as HTMLSelectElement)?.selectedOptions[0].value.split(',')
        }
        return {
            productErpNumber: (document.getElementById('filter_Product') as HTMLInputElement)?.value ?? '',
            poNumber: (document.getElementById('filter_PONumber') as HTMLInputElement)?.value ?? '',
            orderNumber: (document.getElementById('filter_OrderNumber') as HTMLInputElement)?.value ?? '',
            fromDate: fromDate,
            toDate: toDate,
            customerSequence: (document.getElementById('filter_ShipTo') as HTMLSelectElement)?.selectedOptions[0]?.value ?? '',
            status: status,
            orderTotalOperator: (document.getElementById('filter_OrderType') as HTMLSelectElement)?.selectedOptions[0]?.value ?? '',
            orderTotal: total,
            sort: (document.getElementById('filter_Sort') as HTMLInputElement)?.value ?? '',
        };
    }; 

    const renderTable = (data:any): void => {
        let resultHtml = new DOMParser().parseFromString(data, "text/html");
        if (document.getElementById('orderHistoryTable') != null && resultHtml.getElementById('orderHistoryTable') != null) {
            document.getElementById('orderHistoryTable').outerHTML = resultHtml.getElementById('orderHistoryTable').outerHTML;
        }
        document.getElementById('orderHistory_TotalOrders').innerText = (document.getElementById('orderHistory_TotalCount') as HTMLInputElement).value + ' orders ';
        init();
    };

    init();
};

export default orderHistory;
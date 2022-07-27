import filterOption from '../models/filterOption'
import axios from "axios";

const productList = (): void => {

    let urlParamters = "";
    let rootUrl = "";
    let queryStringPos = window.location.href.indexOf('?');

    if (queryStringPos === -1) {
        rootUrl = window.location.href;
    } else {
        rootUrl = window.location.href.substr(0, window.location.href.indexOf('?'));
    }
    const init = (): void => {
        const filterElements = document.getElementsByClassName('actionUpdatePage') as HTMLCollectionOf<HTMLElement>;
        const arr = Array.from(filterElements);
        arr.forEach(element => {
            element.addEventListener("click", (e: MouseEvent) => {
                const data = element.getAttribute('data') ?? '';
                if (element.classList.contains('actionPaginate')) {
                    paginate(data);
                }

                if (element.classList.contains('actionPageSize')) {
                    changePageSize(data);
                }

                if (element.classList.contains('actionSort')) {
                    sort(data);
                }

                if (element.classList.contains('actionViewMode')) {
                    changeViewMode(data);
                }

                if (element.classList.contains('actionFacet')) {
                    let inputElement = element.childNodes[0] as HTMLInputElement;
                    if (inputElement) {
                        inputElement.checked = true;
                        search();
                    }
                }
            });
        });
    };

    const paginate = (page: string): void => {
        var inputElement = <HTMLInputElement>document.querySelector('.actionPageInfo');
        if (!inputElement) {
            return;
        }
        inputElement.value = page;
        search();
    };

    const sort = (sortBy: string): void => {
        var inputElement = <HTMLInputElement>document.querySelector('.actionSortInfo');
        if (!inputElement) {
            return;
        }
        inputElement.value = sortBy;
        search();
    };

    const changePageSize = (pageSize: string): void => {
        var inputElement = <HTMLInputElement>document.querySelector('.actionPageSizeInfo');
        if (!inputElement) {
            return;
        }
        inputElement.value = pageSize;
        search();
    }

    const changeViewMode = (mode: string): void => {
        var inputElement = <HTMLInputElement>document.querySelector('.actionViewModeInfo');
        if (!inputElement) {
            return;
        }
        inputElement.value = mode;
        search();
    }

    const getFilter = (): filterOption => {
        let q = {
            page: Number((document.querySelector('.actionPageInfo') as HTMLInputElement).value),
            pageSize: Number((document.querySelector('.actionPageSizeInfo') as HTMLInputElement).value),
            sort: Number((document.querySelector('.actionSortInfo') as HTMLInputElement).value),
            viewMode: (document.querySelector('.actionViewModeInfo') as HTMLInputElement).value
        } as filterOption;

        urlParamters = getUrlWithFacets();
        return q;
    }

    const search = (): void => {
        let data = getFilter();
        let loading = document.getElementById('loading-box') as HTMLElement;
        if (loading) {
            loading.classList.remove("hidden");
        }

        axios({ url: rootUrl + urlParamters, params: { ...data }, method: 'get' })
            .then(function (result) {
                window.history.replaceState(null, '', urlParamters == "" ? "?" : urlParamters);
                let resultHtml = new DOMParser().parseFromString(result.data, "text/html");
                if (document.querySelector('.actionToolbar') != null && resultHtml.querySelector('.actionToolbar') != null) {
                    document.querySelector('.actionToolbar').outerHTML = resultHtml.querySelector('.actionToolbar').outerHTML;
                }

                if (document.querySelector('.actionFacets') != null && resultHtml.querySelector('.actionFacets') != null) {
                    document.querySelector('.actionFacets').outerHTML = resultHtml.querySelector('.actionFacets').outerHTML;
                }
                if (document.querySelector('.actionProducts') != null && resultHtml.querySelector('.actionProducts') != null) {
                    document.querySelector('.actionProducts').outerHTML = resultHtml.querySelector('.actionProducts').outerHTML;
                }

                init();
            })
            .catch(function (error) {
                //notification.error(error);
            })
            .finally(function () {
                if (loading) {
                    loading.classList.add("hidden");
                }
            });
    };

    const getUrlWithFacets = (): string => {
        let facets = Array<string>();
        const filterElements = document.querySelectorAll('.actionSearchFacet:checked');
        const arr = Array.from(filterElements);
        arr.forEach(element => {
            let selectedFacet = encodeURIComponent(element.getAttribute('data-facetkey') ?? '');
            facets.push(selectedFacet);
        });
        return getUrl(facets);
    };

    const getUrl = (facets: Array<string>): string => {
        let urlParams = getUrlParams();
        urlParams.facets = facets ? facets.join(',') : null;
        //let sort = $('.jsSearchSort')[0].value;
        urlParams.sort = '';
        let url = "?";
        for (let key in urlParams) {
            let value = urlParams[key];
            if (value) {
                url += key + '=' + value + '&';
            }
        }
        return url.slice(0, -1); //remove last char
    };

    const getUrlParams = (): { [index: string]: any } => {
        let match,
            search = /([^&=]+)=?([^&]*)/g, //regex to find key value pairs in querystring
            query = window.location.search.substring(1);

        let urlParams: { [index: string]: any } = {}
        while (match = search.exec(query)) {
            urlParams[match[1]] = match[2];
        }
        return urlParams;
    }

    init();
};

export default productList;
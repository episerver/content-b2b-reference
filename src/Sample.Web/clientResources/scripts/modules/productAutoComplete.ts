export default () => ({
    search: '',
    showResults: false,
    products: [],
    isLoading: false,
    initialized: false,

    getProducts() {
        this.isLoading = true;
        this.products = [];
        fetch('/quickorderpage/autocompleteproducts?term=' + this.search)
            .then(res => res.json())
            .then(data => {
                this.products = data;
                this.showResults = true;
            })
            .then(e => window.quickOrderInit());
        this.isLoading = false;
    }
})
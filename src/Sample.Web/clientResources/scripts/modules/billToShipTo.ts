export default () => ({
    selectedBillTo: '',
    billTos: [],
    selectedShipTo: '',
    shipTos: [],
    isLoading: false,
    initialized: false,

    getBillTos() {
        this.isLoading = true;
        fetch('/header/getbilltos')
            .then(res => res.json())
            .then(data => {
                this.billTos = data;
                this.selectedBillTo = data[0].id;
                if (!this.initialized) {
                    this.getShipTos();
                    this.initialized = true;
                }
            });
        this.isLoading = false;
    },
    getShipTos() {
        this.isLoading = true;
        fetch('/header/getshiptos?billTo=' + this.selectedBillTo)
            .then(res => res.json())
            .then(data => this.shipTos = data);
        this.isLoading = false;
    },
    init() {
        this.getBillTos();
    }
})
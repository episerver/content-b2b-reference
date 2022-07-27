export default () => ({
    selectedCarrier: '',
    carriers: [],
    selectedService: '',
    services: [],
    isLoading: false,
    initialized: false,

    getCarriers() {
        this.isLoading = true;
        fetch('/checkoutpage/getcarriers')
            .then(res => res.json())
            .then(data => {
                this.carriers = data;
                this.selectedCarrier = data[0].id;
                if (!this.initialized) {
                    this.getServices();
                    this.initialized = true;
                }
            });
        this.isLoading = false;
    },
    getServices() {
        this.isLoading = true;
        fetch('/checkoutpage/getcarrierservices?carrierId=' + this.selectedCarrier)
            .then(res => res.json())
            .then(data => this.services = data);
        this.isLoading = false;
    },
    init() {
        this.getCarriers();
    }
})
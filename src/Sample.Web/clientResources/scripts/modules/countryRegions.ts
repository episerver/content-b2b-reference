export default (param: string) => ({
    selectedCountry: param,
    countries: [],
    selectedRegion: '',
    regions: [],
    isLoading: false,
    initialized: false,

    getCountries() {
        this.isLoading = true;
        fetch('/checkoutpage/getcountries')
            .then(res => res.json())
            .then(data => {
                this.countries = data;
                if (!this.initialized) {
                    if (this.selectedCountry === null || this.selectedCountry === '') {
                        this.selectedCountry = data[0].id;
                    }
                    this.getStates();
                    this.initialized = true;
                }
            });
        this.isLoading = false;
    },
    getStates() {
        this.isLoading = true;
        fetch('/checkoutpage/getstates?countryId=' + this.selectedCountry)
            .then(res => res.json())
            .then(data => this.regions = data);
        this.isLoading = false;
    },
    init() {
        this.getCountries();
    }
})
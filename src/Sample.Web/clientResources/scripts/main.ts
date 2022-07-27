import Alpine from 'alpinejs';
import productList from "./modules/productList";
import product from "./modules/product";
import cart from "./modules/cart";
import checkout from "./modules/checkout";
import countryRegions from "./modules/countryRegions";
import carrierServices from "./modules/carrierServices";
import tokenex from "./modules/tokenex";
import orderHistory from './modules/orderHistory';
import billToShipTo from './modules/billToShipTo';
import header from './modules/header';
import addresses from './modules/addresses';
import productAutoComplete from './modules/productAutoComplete';
import quickOrder from './modules/quickOrder';


header();
productList();
product();
cart();
checkout();
orderHistory();
addresses();
tokenex();
quickOrder();
Alpine.data('countryRegions', (param:string) => countryRegions(param) );
Alpine.data('carrierServices', carrierServices);
Alpine.data('billToShipTo', billToShipTo);
Alpine.data('productAutoComplete', productAutoComplete);
Alpine.store('quickorderItems', []);
window.Alpine = Alpine;
Alpine.start();


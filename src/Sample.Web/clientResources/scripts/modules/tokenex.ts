import axios from "axios";
const tokenex = (): void => {
    const init = (): void => {
        const paymentMethods = document.getElementById('checkout_PaymentMethods') as HTMLSelectElement;
        if (paymentMethods) {
            paymentMethods.addEventListener('change', (event: Event) => {
                const newCardDiv = document.getElementById('paymentMethodNewCard') as HTMLElement;
                const existingCardDiv = document.getElementById('paymentMethodExistingCard') as HTMLElement;
                if ((event.target?.value ?? '') === 'CC') {
                    newCardDiv.classList.remove('hidden');
                    existingCardDiv.classList.add('hidden')
                    setupNewCard();
                }
                else {
                    newCardDiv.classList.add('hidden');
                    existingCardDiv.classList.remove('hidden');
                    setuExistingCard(event.target?.value);
                }
            });
        }
        setupNewCard();
    };

    const convertApiDataToTokenExCardType = (cardType: string) => {
        const loweredCardType = cardType.toLowerCase();

        if (loweredCardType === "mastercard") {
            return "masterCard";
        }
        if (loweredCardType === "american express") {
            return "americanExpress";
        }

        return loweredCardType;
    };

    const setuExistingCard = (selectedCard: string): void => {
        if (document.getElementById("savedTokenExSecurityCode") === null) {
            return;
        }

        const selectedPaymentMethod = document.getElementById("checkout_PaymentMethods") as HTMLSelectElement;
        const origin = (document.getElementById("txOrigin") as HTMLInputElement).value;
        const token = selectedCard;
        let cardType = selectedPaymentMethod.options[selectedPaymentMethod.selectedIndex].text;
        cardType = convertApiDataToTokenExCardType(cardType.substring(0, cardType.indexOf(' ')));
        let data = null;

        axios({
            url: '/checkoutpage/getauthenticationkey?token=' + token + '&origin=' + origin,
            method: "GET",
        }).then(function (result) {
            if (result.data) {
                data = result.data;
                if (data === null) {
                    return;
                }
                const cvvIframeConfig = {
                    pci: true,
                    enablePrettyFormat: true,
                    debug: false,
                    placeholder: "CVV",
                    allowUnknownCardTypes: false,
                    origin: origin,
                    timestamp: data.timestamp,
                    tokenScheme: data.tokenScheme,
                    tokenExID: data.tokenExId,
                    token: token,
                    authenticationKey: data.authenticationKey,
                    enableValidateOnBlur: true,
                    cvv: true,
                    inputType: "text",
                    cvvOnly: true,
                    cardType: cardType,
                    styles: {
                        base: "padding-left: 0.75rem; padding-right: 0.75rem; padding-top: 0.5rem; padding-bottom: 0.5rem; background-color: rgb(243 244 246); border-width: 1px; border-radius: 0.375rem; -webkit-appearance: none; -moz-appearance: none; appearance: none; width: 93%; margin-bottom: 0.25rem;",
                        error: "box-shadow: 0 0 6px 0 rgba(224, 57, 57, 0.5);border: 1px solid rgba(224, 57, 57, 0.5);",
                    },
                    cvvInputType: "Number"
                };

                window.tokenFrame = new TokenEx.Iframe("savedTokenExSecurityCode", cvvIframeConfig);
                window.tokenFrame.on("tokenize", (data) => {
                    window.submitCart(data.token, data.cardType);
                });
                window.tokenFrame.load();
            }
        }).catch(function (e) {
            console.log(e);
            return;
        });
    };

    const setupNewCard = (): void => {
        if (document.getElementById("tokenExCardNumber") === null) {
            return;
        }

        const iframeConfig = {
            pci: true,
            enablePrettyFormat: true,
            debug: false,
            placeholder: "CC Number",
            allowUnknownCardTypes: false,
            origin: (document.getElementById("txOrigin") as HTMLInputElement)?.value ?? '',
            timestamp: (document.getElementById("txTimestamp") as HTMLInputElement)?.value ?? '',
            tokenExID: (document.getElementById("txTokenExId") as HTMLInputElement)?.value ?? '',
            tokenScheme: (document.getElementById("txTokenScheme") as HTMLInputElement)?.value ?? '',
            authenticationKey: (document.getElementById("txAuthenticationKey") as HTMLInputElement)?.value ?? '',
            enableValidateOnBlur: true,
            cvv: true,
            cvvContainerID: "tokenExSecurityCode",
            cvvPlaceholder: "CVV",
            inputType: "text",
            styles: {
                base: "padding-left: 0.75rem; padding-right: 0.75rem; padding-top: 0.5rem; padding-bottom: 0.5rem; background-color: rgb(243 244 246); border-width: 1px; border-radius: 0.375rem; -webkit-appearance: none; -moz-appearance: none; appearance: none; width: 93%; margin-bottom: 0.25rem;",
                error: "box-shadow: 0 0 6px 0 rgba(224, 57, 57, 0.5);border: 1px solid rgba(224, 57, 57, 0.5);",
                cvv: {
                    base: "padding-left: 0.75rem; padding-right: 0.75rem; padding-top: 0.5rem; padding-bottom: 0.5rem; background-color: rgb(243 244 246); border-width: 1px; border-radius: 0.375rem; -webkit-appearance: none; -moz-appearance: none; appearance: none; width: 93%; margin-bottom: 0.25rem;",
                    error: "box-shadow: 0 0 6px 0 rgba(224, 57, 57, 0.5);border: 1px solid rgba(224, 57, 57, 0.5);",
                }
            },
            cvvInputType: "Number"
        };

        window.tokenFrame = new TokenEx.Iframe("tokenExCardNumber", iframeConfig);
        window.tokenFrame.on("tokenize", (data) => {
            window.submitCart(data.token, data.cardType);
        });
        window.tokenFrame.load();
    };

    window.onload = ():void => {
        init();
    };
}

export default tokenex;
const defaultTheme = require('tailwindcss/defaultTheme')
module.exports = {
    content: ["./Features/**/*.cshtml", "clientResources/**/*.ts"],
    theme: {
        screens: {
            'xs': '475px',
            ...defaultTheme.screens,
        },
    },

    safelist: [
        {
            pattern: /^bg-/
        },
        {
            pattern: /^text-/
        },
        {
            pattern: /^border-/
        },
        {
            pattern: /^basis-/
        },
        {
            pattern: /^m-/
        },
        {
            pattern: /^p-/
        }
    ],

    variants: {
        extend: {},
    }
}
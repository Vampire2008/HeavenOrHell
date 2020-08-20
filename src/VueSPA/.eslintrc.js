module.exports = {
	"env": {
		"browser": true,
		"es6": true
	},
	"extends": [
		"eslint:recommended",
		"plugin:vue/essential",
		"plugin:@typescript-eslint/eslint-recommended"
	],
	"globals": {
		"Atomics": "readonly",
		"SharedArrayBuffer": "readonly"
	},
	"parserOptions": {
		"ecmaVersion": 2018,
		"parser": "@typescript-eslint/parser",
		"sourceType": "module"
	},
	"plugins": [
		"vue",
		"@typescript-eslint"
	],
	"rules": {
		// "indent": [
		// 	"error",
		// 	"tab"
		// ],
		"linebreak-style": [
			"error",
			"windows"
		],
		"quotes": [
			"error",
			"double"
		],
		"semi": [
			"error",
			"always"
		],
		"vue/script-indent": [
			"error",
			"tab", {
				"baseIndent": 1
			}
		],
		"no-unused-vars": "warn",
		"vue/no-unused-components": "warn"
	}
};

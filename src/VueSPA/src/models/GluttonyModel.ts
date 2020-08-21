import type FoodTime from "./FoodTime";

interface GluttonyModel {
	eatingInDay: number,
	cookies: boolean,
	mostImportantType: Array<FoodTime>,
	fastFood: boolean
}

export default GluttonyModel;

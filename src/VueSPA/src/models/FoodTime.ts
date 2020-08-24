enum FoodTime {
	No = 0,
	Breakfast = 1,
	Brunch = 2,
	Lunch = 4,
	AfternoonSnack = 8,
	Dinner = 16,
	LateSupper = 32,
	BeforeBattle = 64
}

function foodTimeGetDisplayName(foodTime: FoodTime) {
	switch (foodTime) {
		case FoodTime.Breakfast:
			return "Breakfast";
		case FoodTime.Brunch:
			return "Brunch";
		case FoodTime.Lunch:
			return "Lunch";
		case FoodTime.AfternoonSnack:
			return "Afternoon snack";
		case FoodTime.Dinner:
			return "Dinner";
		case FoodTime.LateSupper:
			return "Late supper";
		case FoodTime.BeforeBattle:
			return "Before battle";
	}
}

function foodTimeToNumber(arr: Array<FoodTime>): number {
	let result = 0;
	for (var ft of arr) {
		result |= ft;
	}
	return result;
}

function foodTimeToArray(num: number) {
	const arr: FoodTime[] = [];

	for (var ftName in FoodTime) {
		const numVal = parseInt(ftName);
		if (isNaN(num) || numVal === 0) continue;
		if ((num & numVal) === numVal) {
			arr.push((numVal as FoodTime));
		}
	}
	return arr;
}

export default FoodTime;
export { foodTimeGetDisplayName, foodTimeToArray, foodTimeToNumber };

enum FoodTime {
	Breakfast = 0,
	Brunch = 1,
	Lunch = 2,
	AfternoonSnack = 4,
	Dinner = 8,
	LateSupper = 16,
	BeforeBattle = 32
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

export default FoodTime;
export { foodTimeGetDisplayName };

enum FoodTime {
	Breakfast,
	Brunch,
	Lunch,
	AfternoonSnack,
	Dinner,
	LateSupper,
	BeforeBattle
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

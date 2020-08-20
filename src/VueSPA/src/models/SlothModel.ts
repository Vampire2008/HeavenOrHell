import ReactionOnAccidentType from "./ReactionOnAccidentType";
import ServantsType from "./ServantsType";

interface SlothModel {
	passiveRest: boolean,
	reactionOnAccident: ReactionOnAccidentType,
	servants: ServantsType,
	lazyDescription: string
}

export default SlothModel;

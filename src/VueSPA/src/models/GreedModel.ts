import CollectionType from "./CollectionType";

interface GreedModel {
	hoard: boolean,
	areYouDragon: boolean | null,
	collections: CollectionType,
	tochebleCollection: boolean | null,
	canLendMoney: boolean
}

export default GreedModel;

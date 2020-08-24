import Vue from "vue";
import Vuex from "vuex";
import Gender from "@/models/Gender";
import FoodTime from "@/models/FoodTime";
import CollectionType from "@/models/CollectionType";
import ReactionOnAccidentType from "@/models/ReactionOnAccidentType";
import ServantsType from "@/models/ServantsType";
import WhoFail from "@/models/WhoFail";

Vue.use(Vuex);

export default new Vuex.Store({
	state: {
		uuid: "",
		person: {
			name: "",
			dateOfBirth: null,
			gender: Gender.NoneSpecified,
			color: "#ffffff",
		},
		gluttony: {
			eatingInDay: 0,
			cookies: false,
			mostImportantType: FoodTime.No,
			fastFood: false
		},
		greed: {
			hoard: false,
			areYouDragon: false,
			collections: CollectionType.NoCollection,
			tochebleCollection: false,
			canLendMoney: true,
		},
		sloth: {
			passiveRest: false,
			reactionOnAccident: ReactionOnAccidentType.Help,
			servants: ServantsType.DoMyself,
			lazyDescription: "",
		},
		wrath: {
			easyToAnger: false,
			tryingToControl: false,
			godOfWar: false,
			brokenItems: 0,
		},
		envy: {
			envyToFriend: false,
			tryToAnnoy: false,
			proudOfTheLeader: true,
		},
		pride: {
			acceptFail: true,
			whoFail: WhoFail.Both,
			betterThanOther: false,
		},
		lust: {
			passionDream: false,
			illegalActions: false,
			wasInOrgies: false,
			howManyPartners: 0,
		}
	},
	mutations: {
		saveUuid(state, payload) {
			state.uuid = payload;
		},
		loadState(state, serverData) {
			state.person = serverData.person;
			state.gluttony = serverData.gluttony ?? state.gluttony;
			state.greed = serverData.greed ?? state.greed;
			state.sloth = serverData.sloth ?? state.sloth;
			state.wrath = serverData.wrath ?? state.wrath;
			state.envy = serverData.envy ?? state.envy;
			state.pride = serverData.pride ?? state.pride;
			state.lust = serverData.lust ?? state.lust;
		},
		savePersonal(state, payload) {
			state.person = payload;
		},
		saveGluttony(state, payload) {
			state.gluttony = payload;
		},
		saveGreed(state, payload) {
			state.greed = payload;
		},
		saveSloth(state, payload) {
			state.sloth = payload;
		},
		saveWrath(state, payload) {
			state.wrath = payload;
		},
		saveEnvy(state, payload) {
			state.envy = payload;
		},
		savePride(state, payload) {
			state.pride = payload;
		},
		saveLust(state, payload) {
			state.lust = payload;
		}
	},
	actions: {
	},
	modules: {
	}
});


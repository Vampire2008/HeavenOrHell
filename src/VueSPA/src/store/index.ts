import Vue from "vue";
import Vuex from "vuex";
import Gender from "@/models/Gender";

Vue.use(Vuex);

export default new Vuex.Store({
	state: {
		uuid: "",
		person: {
			name: "",
			dateOfBirth: null,
			gender: Gender.NoneSpecified,
			color: "#ffffff",
		}
	},
	mutations: {
		savePerson(state, payload) {
			state.person = payload;
		}
	},
	actions: {
		init() {

		}
	},
	modules: {
	}
});


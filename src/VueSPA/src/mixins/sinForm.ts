import Vue from "vue";
import axios from "axios";

export default Vue.extend({
	data(): { form: { [propName: string]: any } } {
		return {
			form: {}
		};
	},
	methods: {
		getValuesFromStore(name: string) {
			for (const key in this.form) {
				if (Object.prototype.hasOwnProperty.call(this.form, key)) {
					this.form[key] = this.$store.state[name][key];
				}
			}
		},
		saveForm(name: string): void {
			this.$store.commit(`save${name}`, this.form);
			axios
				.post(`/api/survey/Save${name}`, {
					uuid: this.$store.state.uuid,
					...this.form,
				})
				.then(() => {
					this.$emit("submited", true);
				})
				.catch((error) => {
					console.error(error.toJSON());
					this.$emit("submited", false);
				});
		}
	}
});

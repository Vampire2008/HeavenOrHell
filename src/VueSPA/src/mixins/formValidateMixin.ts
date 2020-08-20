import Vue from "vue";
import { validationMixin } from "vuelidate";

export default Vue.extend({
	mixins: [validationMixin],
	methods: {
		validateState(name: string): boolean | null {
			const { $dirty, $error } = this.$v.form[name] as any;
			return $dirty ? !$error : null;
		},
		validateForm(): boolean {
			this.$v.$touch();
			if (this.$v.$anyError) {
				return false;
			}
			return true;
		}
	}
});

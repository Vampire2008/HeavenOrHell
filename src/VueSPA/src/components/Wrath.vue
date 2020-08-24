<template>
	<div>
		<b-row>
			<b-col>
				<h3>Wrath</h3>
			</b-col>
		</b-row>
		<b-row>
			<b-col>
				<b-form-checkbox v-model="form.easyToAnger">Are you easy to anger?</b-form-checkbox>
				<b-form-checkbox
					v-model="form.tryingToControl"
					:disabled="!form.easyToAnger"
				>Are you trying to control anger?</b-form-checkbox>
				<b-form-checkbox v-model="form.godOfWar" v-if="form.easyToAnger">Are you like a God of war?</b-form-checkbox>
				<b-form-group label="How many items do you broke?">
					<b-form-input type="number" v-model.number="form.brokenItems" min="0"></b-form-input>
				</b-form-group>
			</b-col>
		</b-row>
	</div>
</template>

<script lang="ts">
	import type WrathModel from "@/models/WrathModel";
	import mixins from "vue-typed-mixins";
	import formValidateMixin from "@/mixins/formValidateMixin";
	import { minValue } from "vuelidate/lib/validators";
	import sinForm from "@/mixins/sinForm";

	export default mixins(formValidateMixin, sinForm).extend({
		data(): { form: WrathModel } {
			return {
				form: {
					easyToAnger: false,
					tryingToControl: false,
					godOfWar: false,
					brokenItems: 0,
				},
			};
		},
		validations: {
			form: {
				brockenItems: {
					minValue: minValue(0),
				},
			},
		},
		methods: {
			submit(): void {
				if (!this.validateForm()) {
					this.$emit("submited", false);
					return;
				}
				this.saveForm("Wrath");
			},
		},
		created() {
			this.getValuesFromStore("wrath");
		},
	});
</script>

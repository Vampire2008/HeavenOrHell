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
				<b-form-checkbox
					v-model="form.godOfWar"
					v-if="form.easyToAnger && form.tryingToControl"
				>Are you like a God of war?</b-form-checkbox>
				<b-form-group label="How many items do you broke?">
					<b-form-input type="number" v-model.number="form.brockenItems" min="0"></b-form-input>
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

	export default mixins(formValidateMixin).extend({
		data(): { form: WrathModel } {
			return {
				form: {
					easyToAnger: false,
					tryingToControl: false,
					godOfWar: false,
					brockenItems: 0,
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
			submit(): boolean {
				if (!this.validateForm()) {
					return false;
				}
				//TODO: save
				return true;
			},
		},
	});
</script>

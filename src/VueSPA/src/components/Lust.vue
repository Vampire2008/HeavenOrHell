<template>
	<div>
		<b-row>
			<b-col>
				<h3>Lust</h3>
			</b-col>
		</b-row>
		<b-row>
			<b-col>
				<b-form-checkbox v-model="form.passionDream">Do you have any passion dream?</b-form-checkbox>
				<b-form-checkbox
					v-model="form.illegalActions"
					:disabled="!form.passionDream"
				>Will you do anything (including illegal actions) for a dream?</b-form-checkbox>
				<b-form-checkbox v-model="form.wasInOrgies">Have you taken part in orgies?</b-form-checkbox>
				<b-form-group label="How many partners did you have?">
					<b-form-input
						type="number"
						v-model.number="form.howManyPartners"
						min="0"
						:state="validateState('howManyPartners')"
					></b-form-input>
				</b-form-group>
			</b-col>
		</b-row>
	</div>
</template>

<script lang="ts">
	import Vue from "vue";
	import type LustModel from "@/models/LustModel";
	import mixins from "vue-typed-mixins";
	import formValidateMixin from "@/mixins/formValidateMixin";
	import { minValue } from "vuelidate/lib/validators";

	export default mixins(formValidateMixin).extend({
		data(): { form: LustModel } {
			return {
				form: {
					passionDream: false,
					illegalActions: false,
					wasInOrgies: false,
					howManyPartners: 0,
				},
			};
		},
		validations: {
			form: {
				howManyPartners: {
					minValue: minValue(0),
				},
			},
		},
		methods: {
			submit(): boolean {
				if (!this.validateForm()) return false;

				//TODO: Save data
				return true;
			},
		},
	});
</script>

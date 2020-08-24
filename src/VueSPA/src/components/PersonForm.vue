<template>
	<div>
		<b-row>
			<b-col>
				<p>Please, fill some information about yourself.</p>
			</b-col>
		</b-row>
		<b-row>
			<b-col>
				<b-form-group label="Name:" label-for="name">
					<b-form-input
						v-model.trim="form.name"
						id="name"
						@blur="nameOnLostFocus"
						:state="validateState('name')"
					></b-form-input>
				</b-form-group>
				<b-form-group label="Date of birth:" label-for="dateOfBirth">
					<b-datepicker v-model="form.dateOfBirth" :state="validateState('dateOfBirth')" value-as-date></b-datepicker>
				</b-form-group>
				<b-form-group label="Gender:">
					<b-form-radio-group v-model="form.gender">
						<b-form-radio :value="genders.NoneSpecified">{{ genderGetDisplayName(genders.NoneSpecified) }}</b-form-radio>
						<b-form-radio :value="genders.Male">{{ genderGetDisplayName(genders.Male) }}</b-form-radio>
						<b-form-radio :value="genders.Female">{{ genderGetDisplayName(genders.Female) }}</b-form-radio>
						<b-form-radio
							:value="genders.StrikeHelicopter"
						>{{ genderGetDisplayName(genders.StrikeHelicopter) }}</b-form-radio>
					</b-form-radio-group>
				</b-form-group>
				<b-form-group label="Favorite color" label-for="favoriteColor">
					<b-form-input v-model="form.color" type="color" id="favoriteColor"></b-form-input>
				</b-form-group>
			</b-col>
		</b-row>
	</div>
</template>

<script lang="ts">
	import type PersonFormInput from "../models/PersonFormInput";
	import Gender from "../models/Gender";
	import { genderGetDisplayName } from "../models/Gender";
	import formValidateMixin from "@/mixins/formValidateMixin";
	import { required } from "vuelidate/lib/validators";
	import mixins from "vue-typed-mixins";
	import axios from "axios";
	import sinForm from "@/mixins/sinForm";

	export default mixins(formValidateMixin, sinForm).extend({
		data(): { form: PersonFormInput; genders: typeof Gender } {
			return {
				form: {
					name: "",
					dateOfBirth: null,
					gender: Gender.NoneSpecified,
					color: "#ffffff",
				},
				genders: Gender,
			};
		},
		validations: {
			form: {
				name: {
					required,
				},
				dateOfBirth: {
					required,
				},
			},
		},
		methods: {
			nameOnLostFocus() {
				// this.form.name = this.form.name.trim();
			},
			genderGetDisplayName,
			submit(): void {
				if (!this.validateForm()) {
					// return false;
					this.$emit("submited", false);
					return;
				}
				this.saveForm("Personal");
				// return true;
			},
		},
		created() {
			this.getValuesFromStore("person");
		},
	});
</script>

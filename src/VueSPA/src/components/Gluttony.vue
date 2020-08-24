<template>
	<div>
		<b-row>
			<b-col>
				<h3>Gluttony</h3>
			</b-col>
		</b-row>
		<b-row>
			<b-col>
				<b-form-group label="How many times you eat in a day?">
					<b-form-input
						type="number"
						v-model.number="form.eatingInDay"
						min="0"
						:state="validateState('eatingInDay')"
					></b-form-input>
				</b-form-group>
				<!-- <b-form-group label="Do you like cookies?"> -->
				<b-form-checkbox v-model="form.cookies">Do you like cookies?</b-form-checkbox>
				<b-form-checkbox v-model="form.fastFood">Do you like fast food?</b-form-checkbox>
				<!-- </b-form-group> -->
				<b-form-group label="Most important food time:">
					<b-form-checkbox-group v-model="form.mostImportantType" stacked>
						<b-form-checkbox
							:value="foodTimes.Breakfast"
						>{{ foodTimeGetDisplayName(foodTimes.Breakfast) }}</b-form-checkbox>
						<b-form-checkbox :value="foodTimes.Brunch">{{ foodTimeGetDisplayName(foodTimes.Brunch) }}</b-form-checkbox>
						<b-form-checkbox :value="foodTimes.Lunch">{{ foodTimeGetDisplayName(foodTimes.Lunch) }}</b-form-checkbox>
						<b-form-checkbox
							:value="foodTimes.AfternoonSnack"
						>{{ foodTimeGetDisplayName(foodTimes.AfternoonSnack) }}</b-form-checkbox>
						<b-form-checkbox :value="foodTimes.Dinner">{{ foodTimeGetDisplayName(foodTimes.Dinner) }}</b-form-checkbox>
						<b-form-checkbox
							:value="foodTimes.LateSupper"
						>{{ foodTimeGetDisplayName(foodTimes.LateSupper) }}</b-form-checkbox>
						<b-form-checkbox
							:value="foodTimes.BeforeBattle"
						>{{ foodTimeGetDisplayName(foodTimes.BeforeBattle) }}</b-form-checkbox>
					</b-form-checkbox-group>
				</b-form-group>
			</b-col>
		</b-row>
	</div>
</template>

<script lang="ts">
	import type GluttonyModel from "@/models/GluttonyModel";
	import {
		default as FoodTime,
		foodTimeGetDisplayName,
		foodTimeToNumber,
		foodTimeToArray,
	} from "@/models/FoodTime";
	import mixins from "vue-typed-mixins";
	import formValidateMixin from "@/mixins/formValidateMixin";
	import { minValue } from "vuelidate/lib/validators";
	import axios from "axios";

	export default mixins(formValidateMixin).extend({
		data(): { form: GluttonyModel; foodTimes: typeof FoodTime } {
			return {
				form: {
					eatingInDay: 0,
					cookies: false,
					mostImportantType: [],
					fastFood: false,
				},
				foodTimes: FoodTime,
			};
		},
		validations: {
			form: {
				eatingInDay: {
					minValue: minValue(0),
				},
			},
		},
		methods: {
			foodTimeGetDisplayName,

			submit(): void {
				if (!this.validateForm()) {
					this.$emit("submited", false);
					return;
				}
				this.$store.commit("saveGluttony", {
					...this.form,
					mostImportantType: foodTimeToNumber(
						this.form.mostImportantType
					),
				});
				axios
					.post("/api/survey/SaveGluttony", {
						uuid: this.$store.state.uuid,
						...this.form,
						mostImportantType: foodTimeToNumber(
							this.form.mostImportantType
						),
					})
					.then(() => {
						this.$emit("submited", true);
					})
					.catch((error) => {
						console.error(error.toJSON());
						this.$emit("submited", false);
					});
			},
		},
		created() {
			this.form.eatingInDay = this.$store.state.gluttony.eatingInDay;
			this.form.cookies = this.$store.state.gluttony.cookies;
			this.form.mostImportantType = foodTimeToArray(
				this.$store.state.gluttony.mostImportantType
			);
			this.form.fastFood = this.$store.state.gluttony.fastFood;
		},
	});
</script>

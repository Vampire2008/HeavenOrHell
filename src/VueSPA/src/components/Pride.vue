<template>
	<div>
		<b-row>
			<b-col>
				<h3>Pride</h3>
			</b-col>
		</b-row>
		<b-row>
			<b-col>
				<b-form-checkbox v-model="form.acceptFail">Are you accept fails?</b-form-checkbox>
				<b-form-group label="If your team failed whose fault is it?">
					<b-form-radio-group v-model="form.whoFail">
						<b-form-radio :value="whoFailTypes.Me">Me</b-form-radio>
						<b-form-radio :value="whoFailTypes.Other">My team</b-form-radio>
						<b-form-radio :value="whoFailTypes.Both">We all</b-form-radio>
					</b-form-radio-group>
				</b-form-group>
				<b-form-checkbox v-model="form.betterThanOther">Are you better then other?</b-form-checkbox>
			</b-col>
		</b-row>
	</div>
</template>

<script lang="ts">
	import Vue from "vue";
	import type PrideModel from "@/models/PrideModel";
	import WhoFail from "@/models/WhoFail";

	export default Vue.extend({
		data(): { form: PrideModel; whoFailTypes: typeof WhoFail } {
			return {
				form: {
					acceptFail: true,
					whoFail: WhoFail.Both,
					betterThanOther: false,
				},
				whoFailTypes: WhoFail,
			};
		},
		methods: {
			submit(): boolean {
				return true;
			},
		},
	});
</script>

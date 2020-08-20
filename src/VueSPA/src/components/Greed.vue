<template>
	<div>
		<b-row>
			<b-col>
				<h3>Greed</h3>
			</b-col>
		</b-row>
		<b-row>
			<b-col>
				<b-form-group label="Are you more hoard or spend?">
					<b-radio-group v-model="form.hoard">
						<b-form-radio :value="true">Hoard</b-form-radio>
						<b-form-radio :value="false">Spend</b-form-radio>
					</b-radio-group>
				</b-form-group>
				<b-form-checkbox v-model="form.areYouDragon" :disabled="!form.hoard">Are you like a dragon?</b-form-checkbox>
				<b-form-group label="Do you have any collection?">
					<b-form-select v-model="form.collections">
						<b-select-option :value="collectionTypes.NoCollection">No</b-select-option>
						<b-select-option :value="collectionTypes.Small">1 or 2 small collection</b-select-option>
						<b-select-option :value="collectionTypes.Big">At least one big collection</b-select-option>
						<b-select-option :value="collectionTypes.Passion">Do you have chinees coin dated 856?</b-select-option>
					</b-form-select>
				</b-form-group>
				<b-form-checkbox
					v-model="form.tochebleCollection"
					:disabled="form.collections === collectionTypes.NoCollection"
				>Can somebody touch your collection?</b-form-checkbox>
				<b-form-checkbox
					v-model="form.canLendMoney"
				>Can you lend something (example: money or axe) to a friend?</b-form-checkbox>
			</b-col>
		</b-row>
	</div>
</template>

<script lang="ts">
	import Vue from "vue";
	import type GreedModel from "@/models/GreedModel";
	import CollectionType from "@/models/CollectionType";

	export default Vue.extend({
		data(): { form: GreedModel; collectionTypes: typeof CollectionType } {
			return {
				form: {
					hoard: false,
					areYouDragon: false,
					collections: CollectionType.NoCollection,
					tochebleCollection: false,
					canLendMoney: true,
				},
				collectionTypes: CollectionType,
			};
		},
		methods: {
			submit() {
				return true;
			},
		},
	});
</script>

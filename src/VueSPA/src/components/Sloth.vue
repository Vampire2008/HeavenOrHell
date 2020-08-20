<template>
	<div>
		<b-row>
			<b-col>
				<h3>Sloth</h3>
			</b-col>
		</b-row>
		<b-row>
			<b-col>
				<b-form-group label="Are you preffer passive or active rest?">
					<b-form-radio-group v-model="form.passiveRest">
						<b-form-radio :value="true">Passive</b-form-radio>
						<b-form-radio :value="false">Active</b-form-radio>
					</b-form-radio-group>
				</b-form-group>
				<b-form-group label="You witnessed an accident. Your reaction?">
					<b-form-select v-model="form.reactionOnAccident">
						<b-select-option :value="reactions.Help">I will help people!</b-select-option>
						<b-select-option :value="reactions.StartRecording">I will start recording a video.</b-select-option>
						<b-select-option :value="reactions.GoAway">I will just go away. It's don't care me.</b-select-option>
						<b-select-option :value="reactions.AtHome">Which accident? I am at home all time.</b-select-option>
					</b-form-select>
				</b-form-group>
				<b-form-group label="Do you want to have servants?">
					<b-form-select v-model="form.servants">
						<b-select-option :value="servantTypes.DoMyself">No, I can do anything myself.</b-select-option>
						<b-select-option :value="servantTypes.Greed">No, I don't want to pay them.</b-select-option>
						<b-select-option :value="servantTypes.Yes">Yes, I want.</b-select-option>
						<b-select-option :value="servantTypes.OnlyMaid">Yes, but I want only maid.</b-select-option>
					</b-form-select>
				</b-form-group>
				<b-form-group label="Please tell about your laziness:">
					<b-form-textarea v-model="form.lazyDescription" :state="validateState('lazyDescription')"></b-form-textarea>
				</b-form-group>
			</b-col>
		</b-row>
	</div>
</template>

<script lang="ts">
	import Vue from "vue";
	import type SlothModel from "@/models/SlothModel";
	import ReactionOnAccidentType from "@/models/ReactionOnAccidentType";
	import ServantsType from "@/models/ServantsType";
	import { validationMixin } from "vuelidate";
	import mixins from "vue-typed-mixins";
	import formValidateMixin from "@/mixins/formValidateMixin";
	import { required } from "vuelidate/lib/validators";

	export default mixins(formValidateMixin).extend({
		data(): {
			form: SlothModel;
			reactions: typeof ReactionOnAccidentType;
			servantTypes: typeof ServantsType;
		} {
			return {
				form: {
					passiveRest: false,
					reactionOnAccident: ReactionOnAccidentType.Help,
					servants: ServantsType.DoMyself,
					lazyDescription: "",
				},
				reactions: ReactionOnAccidentType,
				servantTypes: ServantsType,
			};
		},
		validations: {
			form: {
				lazyDescription: {
					required,
				},
			},
		},
		methods: {
			submit(): boolean {
				if (!this.validateForm()) return false;

				//TODO: Save
				return true;
			},
		},
	});
</script>

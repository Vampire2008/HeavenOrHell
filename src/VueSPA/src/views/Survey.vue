<template>
	<b-card no-body>
		<b-card-header class="text-center">
			<b-row>
				<b-col>
					<template
						v-if="currentStep < steps.length"
					>Step {{ currentStep+1 }} of {{ steps.length }}: {{ steps[currentStep].name }}</template>
					<template v-else>Results</template>
				</b-col>
			</b-row>
			<b-row>
				<b-col>
					<b-progress :max="steps.length" :value="currentStep"></b-progress>
				</b-col>
			</b-row>
		</b-card-header>
		<b-card-body>
			<b-row>
				<b-col>
					<template v-if="currentStep < steps.length">
						<keep-alive>
							<component ref="currentComponent" :is="steps[currentStep].component"></component>
						</keep-alive>
					</template>
					<template v-else>
						<Result></Result>
					</template>
				</b-col>
			</b-row>
			<b-row v-if="currentStep < steps.length">
				<b-col cols="1">
					<b-button type="button" v-if="currentStep > 0" variant="secondary" @click="back">Back</b-button>
				</b-col>
				<b-col cols="1" offset="10">
					<b-button
						type="button"
						variant="success"
						@click="next"
					>{{ currentStep == steps.length-1 ? "Finish" : "Next" }}</b-button>
				</b-col>
			</b-row>
		</b-card-body>
	</b-card>
</template>

<script lang="ts">
	import Vue from "vue";
	import PersonForm from "@/components/PersonForm.vue";
	import Gluttony from "@/components/Gluttony.vue";
	import Greed from "@/components/Greed.vue";
	import Sloth from "@/components/Sloth.vue";
	import Wrath from "@/components/Wrath.vue";
	import Envy from "@/components/Envy.vue";
	import Pride from "@/components/Pride.vue";
	import Lust from "@/components/Lust.vue";
	import Result from "@/components/Result.vue";

	export default Vue.extend({
		components: {
			PersonForm,
			Gluttony,
			Greed,
			Sloth,
			Wrath,
			Envy,
			Pride,
			Lust,
			Result,
		},
		data() {
			return {
				steps: [
					{
						name: "Personal info",
						component: PersonForm,
					},
					{
						name: "Gluttony",
						component: Gluttony,
					},
					{
						name: "Greed",
						component: Greed,
					},
					{
						name: "Sloth",
						component: Sloth,
					},
					{
						name: "Wrath",
						component: Wrath,
					},
					{
						name: "Envy",
						component: Envy,
					},
					{
						name: "Pride",
						component: Pride,
					},
					{
						name: "Lust",
						component: Lust,
					},
				],
				stepsOld: [
					"Personal info",
					"Gluttony",
					"Greed",
					"Sloth",
					"Wrath",
					"Envy",
					"Pride",
					"Lust",
				],
				currentStep: 8,
			};
		},
		methods: {
			next() {
				if (
					!((this.$refs.currentComponent as unknown) as {
						submit: () => boolean;
					}).submit()
				)
					return;
				if (this.currentStep + 1 == this.steps.length) {
					//TODO: Finish logic
					return;
				}
				this.currentStep++;
			},
			back() {
				if (this.currentStep - 1 < 0) return;
				this.currentStep--;
			},
		},
	});
</script>

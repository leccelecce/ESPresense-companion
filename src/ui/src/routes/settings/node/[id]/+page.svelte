<script lang="ts">
    import NodeSettings from '$lib/NodeSettings.svelte';
	/** @type {import('./$types').PageData} */
	export let data;
</script>

<svelte:head>
    <title>ESPresense Companion: {data.title}</title>
</svelte:head>

<div class="container mx-auto p-2">
    <h1 class="text-3xl font-bold my-2 px-2">{data.title}</h1>
    <NodeSettings id="{data.id}" />
</div>

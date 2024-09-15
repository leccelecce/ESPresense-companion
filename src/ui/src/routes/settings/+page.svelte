<script lang="ts">
    import NodeSettings from '$lib/NodeSettings.svelte';
</script>

<svelte:head>
    <title>ESPresense Companion: Settings</title>
</svelte:head>

<div class="container mx-auto p-2">
    <h1 class="text-3xl font-bold my-2 px-2">Global Settings</h1>
    <p class="mb-6 text-lg px-2">These settings will be applied to every node, including new nodes.</p>
    
    <NodeSettings id="*" />
</div>

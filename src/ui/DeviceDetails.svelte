<script lang="ts">
  import { onMount } from 'svelte';
  import type { Device } from '../models/Device';
  import { deviceManager } from '../services/DeviceManager';
  import RssiCalibrationComponent from './RssiCalibrationComponent.svelte';

  export let id: string;

  let device: Device | null = null;

  onMount(async () => {
    device = await deviceManager.getDevice(id);
  });
</script>

<h3>Device Details: {device?.name ?? 'Loading...'}</h3>

{#if device}
  <p>ID: {device.id}</p>
  <p>Name: {device.name}</p>
  <p>RSSI@1m: {device.rssiAt1m}</p>
  <!-- Add more device details here -->

  <RssiCalibrationComponent {device} />
{:else}
  <p>Loading...</p>
{/if}

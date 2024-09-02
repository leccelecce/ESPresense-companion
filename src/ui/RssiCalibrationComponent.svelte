<script lang="ts">
  import { onMount } from 'svelte';
  import type { Device } from '../models/Device';
  import type { Node } from '../models/Node';
  import { deviceManager } from '../services/DeviceManager';
  import { nodeManager } from '../services/NodeManager';

  export let device: Device;

  let nodes: Node[] = [];

  onMount(async () => {
    nodes = await nodeManager.getNodes();
  });

  function getCurrentRssi(node: Node): number | null {
    return device.nodes[node.id]?.rssi ?? null;
  }

  function calibrateRssi(node: Node): void {
    const currentRssi = getCurrentRssi(node);
    if (currentRssi !== null) {
      device.rssiAt1m = currentRssi;
      deviceManager.updateDevice(device);
    }
  }
</script>

<h3>RSSI Calibration</h3>

<table class="table">
  <thead>
    <tr>
      <th>Node</th>
      <th>Current RSSI</th>
      <th>Action</th>
    </tr>
  </thead>
  <tbody>
    {#each nodes as node}
      <tr>
        <td>{node.name}</td>
        <td>{getCurrentRssi(node) ?? 'N/A'}</td>
        <td>
          <button class="btn btn-primary" on:click={() => calibrateRssi(node)}>
            Set RSSI@1m
          </button>
        </td>
      </tr>
    {/each}
  </tbody>
</table>

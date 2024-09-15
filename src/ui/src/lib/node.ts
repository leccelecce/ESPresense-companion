import { base } from '$app/paths';
import type { Node, NodeSetting } from './types';

export async function loadNodeSettings(id: string): Promise<NodeSetting> {
    const response = await fetch(`${base}/api/node/${id}/settings`);
    if (!response.ok) throw new Error("Something went wrong loading settings (error="+response.status+" "+response.statusText+")");
    return await response.json();
}

export async function saveNodeSettings(newSettings: NodeSetting): Promise<void> {
    const response = await fetch(`${base}/api/node/${newSettings.id}/settings`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(newSettings),
    });
    if (!response.ok) throw new Error("Something went wrong saving settings (error="+response.status+" "+response.statusText+")");
}

export async function restartNode(nodeId: string): Promise<void> {
    const response = await fetch(`${base}/api/node/${nodeId}/restart`, { method: 'POST' });
    if (!response.ok) throw new Error(response.statusText);
}

export async function updateNode(nodeId: string): Promise<void> {
    const response = await fetch(`${base}/api/node/${nodeId}/update`, { method: 'POST' });
    if (!response.ok) throw new Error(response.statusText);
}

export async function fetchNodeDetails(nodeId: string): Promise<NodeDetail> {
    const response = await fetch(`${base}/api/node/${nodeId}/details`);
    if (!response.ok) throw new Error(response.statusText);
    return await response.json();
}
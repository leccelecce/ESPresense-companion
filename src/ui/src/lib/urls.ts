import { base } from '$app/paths';
import { goto } from '$app/navigation';
import { isNode, type Device, type Node } from '$lib/types';

export function gotoDetail(d: Device | Node | null) {
	if (isNode(d)) goto(`${base}/nodes/${d?.id}`);
	else goto(`${base}/devices/${d?.id}`);
}

export function gotoSettings(id: string) {
	return goto(`${base}/settings/node/${id}`);
}
import { error } from '@sveltejs/kit';
import type { PageLoad } from './$types';

export const load: PageLoad<{ id: string }> = async ({ params }) => {
	if (!params.id) {
		throw error(400, 'No node id');
	}
	return { id: params.id, title: 'Settings for ' + params.id };
};

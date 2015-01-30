BulletML for Unity
==================

## Changelog

Version 1.3.1 and 1.3.2

- Minor functions creation in BulletManagerScript for integration with other scripts.

Version 1.3

- Added a new tag, `<trigger>`. You can now raise events from BulletML.
See the related documentation (http://pixelnest.io/work/bulletml-for-unity/customization).
- New pattern examples

Breaking changes:
- OnBulletSpawned now provides a GameObject parameter, so you know who is requesting the bullet

Version 1.2

Breaking changes:

- Rewrite GetPlayerPosition handler so the source parameter is now a GameObject
- OnBulletSpawned now should returns a BulletScript, in order to be linked to the manager's TimeSpeed and Scale. 

Version 1.1.3

- Fix bullet destruction with custom handler

Version 1.1.2

- No more [0, 1] limits on TimeSpeed and Scale.
- Reset pattern function
- Fix bullet spawn handler (bank was always executed)

Breaking changes:

- GetPlayerPosition now provides the source bullet as a parameter

Version 1.1.1

- Fix GameManager conflicts by using explicit namespaces in plugin scripts

Version 1.1

- Fixed first bullet (root) having a zero position after creation
- Replaced the BulletMLLib.dll by the whole source code
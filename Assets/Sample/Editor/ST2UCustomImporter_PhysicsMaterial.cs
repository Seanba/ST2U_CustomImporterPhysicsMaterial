using UnityEngine;
using SuperTiled2Unity;
using SuperTiled2Unity.Editor;

// Use this attribute to have this custom importer automatically apply to every TMX asset in your project
[AutoCustomTmxImporter]
public class ST2UCustomImporter_PhysicsMaterial : CustomTmxImporter
{
    public override void TmxAssetImported(TmxAssetImportedArgs args)
    {
        // Steps:
        // 1) For all SuperColliderComponents in the imported Tiled map (a SuperMap)
        // 2) Get the sibling Collider2D component
        // 3) Assign the physics material

        foreach (var superCollider in args.ImportedSuperMap.gameObject.GetComponentsInChildren<SuperColliderComponent>())
        {
            // We generally don't want to use physics materials on triggers
            var collider2d = superCollider.GetComponent<Collider2D>();
            if (collider2d != null && collider2d.isTrigger == false)
            {
                collider2d.sharedMaterial = AssetDatabaseEx.LoadFirstAssetByFilter<PhysicsMaterial2D>("MyPhysicsMaterial2D");
            }
        }
    }
}

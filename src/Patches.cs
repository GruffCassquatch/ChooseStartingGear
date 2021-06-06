using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony;

namespace ChooseStartingGear
{
    class Patches
    {
        [HarmonyPatch(typeof(StartGear), "AddAllToInventory")]
        internal class CustomStartGear
        {
            private static bool Prefix()
            {
                if (Settings.settings.modFunction != ModFunction.Custom) return true;

            // Clothing
                if (Settings.settings.headInner != HeadInner.None) AddClothingItem(Settings.settings.headInner.ToString(), Settings.settings.headInnerCondition);
                if (Settings.settings.headOuter != HeadOuter.None) AddClothingItem(Settings.settings.headOuter.ToString(), Settings.settings.headOuterCondition);
                if (Settings.settings.torsoOuterInner != TorsoOuter.None) AddClothingItem(Settings.settings.torsoOuterInner.ToString(), Settings.settings.torsoOuterInnerCondition);
                if (Settings.settings.torsoOuterOuter != TorsoOuter.None) AddClothingItem(Settings.settings.torsoOuterOuter.ToString(), Settings.settings.torsoOuterOuterCondition);
                if (Settings.settings.torsoInnerInner != TorsoInner.None) AddClothingItem(Settings.settings.torsoInnerInner.ToString(), Settings.settings.torsoInnerInnerCondition);
                if (Settings.settings.torsoInnerOuter != TorsoInner.None) AddClothingItem(Settings.settings.torsoInnerOuter.ToString(), Settings.settings.torsoInnerOuterCondition);
                if (Settings.settings.hands != Hands.None) AddClothingItem(Settings.settings.hands.ToString(), Settings.settings.handsCondition);
                if (Settings.settings.accessoriesInner != AccessoriesInner.None) AddClothingItem(Settings.settings.accessoriesInner.ToString(), Settings.settings.accessoriesInnerCondition);
                if (Settings.settings.accessoriesOuter != AccessoriesOuter.None) AddClothingItem(Settings.settings.accessoriesOuter.ToString(), Settings.settings.accessoriesOuterCondition);
                if (Settings.settings.legsOuterInner != LegsOuter.None) AddClothingItem(Settings.settings.legsOuterInner.ToString(), Settings.settings.legsOuterInnerCondition);
                if (Settings.settings.legsOuterOuter != LegsOuter.None) AddClothingItem(Settings.settings.legsOuterOuter.ToString(), Settings.settings.legsOuterOuterCondition);
                if (Settings.settings.legsInnerInner != LegsInner.None) AddClothingItem(Settings.settings.legsInnerInner.ToString(), Settings.settings.legsInnerInnerCondition);
                if (Settings.settings.legsInnerOuter != LegsInner.None) AddClothingItem(Settings.settings.legsInnerOuter.ToString(), Settings.settings.legsInnerOuterCondition);
                if (Settings.settings.feetInnerInner != FeetInner.None) AddClothingItem(Settings.settings.feetInnerInner.ToString(), Settings.settings.feetInnerInnerCondition);
                if (Settings.settings.feetInnerOuter != FeetInner.None) AddClothingItem(Settings.settings.feetInnerOuter.ToString(), Settings.settings.feetInnerOuterCondition);
                if (Settings.settings.feetOuter != FeetOuter.None) AddClothingItem(Settings.settings.feetOuter.ToString(), Settings.settings.feetOuterCondition);

                // Fire Starting
                if (Settings.settings.firestarter != FireStarter.None)
                {
                    int qty = 1;
                    if (Settings.settings.firestarter == FireStarter.GEAR_PackMatches || Settings.settings.firestarter == FireStarter.GEAR_WoodMatches) qty = Settings.settings.matchQty;
                    GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.firestarter.ToString(), qty);
                }
                if (Settings.settings.tinderType != Tinder.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.tinderType.ToString(), Settings.settings.tinderQty);
                if (Settings.settings.fuelType != Fuel.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.fuelType.ToString(), Settings.settings.fuelQty);
                if (Settings.settings.accelerant) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Accelerant");

            // First Aid
                if (Settings.settings.antibiotics != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_BottleAntibiotics", Settings.settings.antibiotics);
                if (Settings.settings.antiseptic != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_BottleHydrogenPeroxide", Settings.settings.antiseptic);
                if (Settings.settings.bandages != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_HeavyBandage", Settings.settings.bandages);
                if (Settings.settings.emergencyStim != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_EmergencyStim", Settings.settings.emergencyStim);
                if (Settings.settings.oldMansBeardDressing != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_OldMansBeardDressing", Settings.settings.oldMansBeardDressing);
                if (Settings.settings.painkillers != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_BottlePainKillers", Settings.settings.painkillers);
                if (Settings.settings.preparedBirchBark != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_BirchbarkPrepared", Settings.settings.preparedBirchBark);
                if (Settings.settings.preparedReshiMushrooms != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_ReishiPrepared", Settings.settings.preparedReshiMushrooms);
                if (Settings.settings.preparedRoseHips != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_RosehipsPrepared", Settings.settings.preparedRoseHips);
                if (Settings.settings.waterPurificationTablets != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_WaterPurificationTablets", Settings.settings.waterPurificationTablets);

            // Food and Drink
                if (Settings.settings.food1 != Food.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.food1.ToString());
                if (Settings.settings.food2 != Food.None)GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.food2.ToString());
                if (Settings.settings.drink1 != Drink.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.drink1.ToString());
                if (Settings.settings.drink2 != Drink.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.drink2.ToString());

            // Tools
                if (Settings.settings.bedroll != Bedroll.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.bedroll.ToString());
                if (Settings.settings.canOpener) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_CanOpener");
                if (Settings.settings.cooking != Cooking.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.cooking.ToString());
                if (Settings.settings.fishingTackle != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_HookAndLine", Settings.settings.fishingTackle);
                if (Settings.settings.hacksaw) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Hacksaw");
                if (Settings.settings.hatchet != Hatchet.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.hatchet.ToString());
                if (Settings.settings.heavyHammer) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Hammer");
                if (Settings.settings.knife != Knife.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.knife.ToString());
                if (Settings.settings.lightSource != LightSources.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.lightSource.ToString());
                if (Settings.settings.mountaineeringRope) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Rope");
                if (Settings.settings.prybar) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Prybar");
                if (Settings.settings.rifleCleaningKit) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_RifleCleaningKit");
                if (Settings.settings.sewingKit) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_SewingKit");
                if (Settings.settings.snare) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Snare");
                if (Settings.settings.sprayPaint) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_SprayPaintCan");
                if (Settings.settings.toolBox != ToolBox.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.toolBox.ToString());
                if (Settings.settings.weapon != Weapons.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.weapon.ToString());
                if (Settings.settings.ammunitionQty != 0)
                {
                    switch (Settings.settings.weapon) 
                    {
                        case Weapons.None:
                            break;
                        case Weapons.GEAR_FlareGun:
                            GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_FlareGunAmmoSingle", Settings.settings.ammunitionQty);
                            break;
                        case Weapons.GEAR_Rifle:
                            GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_RifleAmmoSingle", Settings.settings.ammunitionQty);
                            break;
                        case Weapons.GEAR_Revolver:
                            GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_RevolverAmmoSingle", Settings.settings.ammunitionQty);
                            break;
                        case Weapons.GEAR_Bow:
                            GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Arrow", Settings.settings.ammunitionQty);
                            break;
                    }
                }
                if (Settings.settings.whetstone) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_SharpeningStone");

            // Materials
                if (Settings.settings.arrowhead != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_ArrowHead", Settings.settings.arrowhead);
                if (Settings.settings.arrowShaft != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_ArrowShaft", Settings.settings.arrowShaft);
                if (Settings.settings.bullet != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Bullet", Settings.settings.bullet);
                if (Settings.settings.gunpowder != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_GunpowderCan", Settings.settings.gunpowder);
                if (Settings.settings.charcoal != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Charcoal", Settings.settings.charcoal);
                if (Settings.settings.crowFeather != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_CrowFeather", Settings.settings.crowFeather);
                if (Settings.settings.dustingSulfur != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_DustingSulfur", Settings.settings.dustingSulfur);
                if (Settings.settings.revolverShell != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_RevolverAmmoCasing", Settings.settings.revolverShell);
                if (Settings.settings.rifleShell != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_RifleAmmoCasing", Settings.settings.rifleShell);
                if (Settings.settings.scrapLead != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_ScrapLead", Settings.settings.scrapLead);
                if (Settings.settings.stumpRemover != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_StumpRemover", Settings.settings.stumpRemover);

                if (Settings.settings.bearHideCured != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_BearHideDried", Settings.settings.bearHideCured);
                if (Settings.settings.bearHideFresh != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_BearHide", Settings.settings.bearHideFresh);
                if (Settings.settings.deerHideCured != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_LeatherHideDried", Settings.settings.deerHideCured);
                if (Settings.settings.deerHideFresh != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_LeatherHide", Settings.settings.deerHideFresh);
                if (Settings.settings.gutCured != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_GutDried", Settings.settings.gutCured);
                if (Settings.settings.gutFresh != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Gut", Settings.settings.gutFresh);
                if (Settings.settings.mooseHideCured != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_MooseHideDried", Settings.settings.mooseHideCured);
                if (Settings.settings.mooseHideFresh != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_MooseHide", Settings.settings.mooseHideFresh);
                if (Settings.settings.rabbitPeltCured != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_RabbitPeltDried", Settings.settings.rabbitPeltCured);
                if (Settings.settings.rabbitPeltFresh != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_RabbitPelt", Settings.settings.rabbitPeltFresh);
                if (Settings.settings.wolfPeltCured != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_WolfPeltDried", Settings.settings.wolfPeltCured);
                if (Settings.settings.wolfPeltFresh != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_WolfPelt", Settings.settings.wolfPeltFresh);

                if (Settings.settings.birchSaplingCured != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_BirchSaplingDried", Settings.settings.birchSaplingCured);
                if (Settings.settings.birchSaplingFresh != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_BirchSapling", Settings.settings.birchSaplingFresh);
                if (Settings.settings.mapleSaplingCured != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_MapleSaplingDried", Settings.settings.mapleSaplingCured);
                if (Settings.settings.mapleSaplingFresh != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_MapleSapling", Settings.settings.mapleSaplingFresh);

                if (Settings.settings.cloth != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Cloth", Settings.settings.cloth);
                if (Settings.settings.curedLeather != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_LeatherDried", Settings.settings.curedLeather);
                if (Settings.settings.scrapMetal != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_ScrapMetal", Settings.settings.scrapMetal);

                return false;
            }
        }

        [HarmonyPatch(typeof(StartGear), "AddAllToInventory")]
        internal class DefaultPlusStartGear
        {
            private static void Postfix()
            {
                if (Settings.settings.modFunction != ModFunction.DefaultPlus) return;

                // Clothing
                if (Settings.settings.headInner != HeadInner.None) AddClothingItem(Settings.settings.headInner.ToString(), Settings.settings.headInnerCondition);
                if (Settings.settings.headOuter != HeadOuter.None) AddClothingItem(Settings.settings.headOuter.ToString(), Settings.settings.headOuterCondition);
                if (Settings.settings.torsoOuterInner != TorsoOuter.None) AddClothingItem(Settings.settings.torsoOuterInner.ToString(), Settings.settings.torsoOuterInnerCondition);
                if (Settings.settings.torsoOuterOuter != TorsoOuter.None) AddClothingItem(Settings.settings.torsoOuterOuter.ToString(), Settings.settings.torsoOuterOuterCondition);
                if (Settings.settings.torsoInnerInner != TorsoInner.None) AddClothingItem(Settings.settings.torsoInnerInner.ToString(), Settings.settings.torsoInnerInnerCondition);
                if (Settings.settings.torsoInnerOuter != TorsoInner.None) AddClothingItem(Settings.settings.torsoInnerOuter.ToString(), Settings.settings.torsoInnerOuterCondition);
                if (Settings.settings.hands != Hands.None) AddClothingItem(Settings.settings.hands.ToString(), Settings.settings.handsCondition);
                if (Settings.settings.accessoriesInner != AccessoriesInner.None) AddClothingItem(Settings.settings.accessoriesInner.ToString(), Settings.settings.accessoriesInnerCondition);
                if (Settings.settings.accessoriesOuter != AccessoriesOuter.None) AddClothingItem(Settings.settings.accessoriesOuter.ToString(), Settings.settings.accessoriesOuterCondition);
                if (Settings.settings.legsOuterInner != LegsOuter.None) AddClothingItem(Settings.settings.legsOuterInner.ToString(), Settings.settings.legsOuterInnerCondition);
                if (Settings.settings.legsOuterOuter != LegsOuter.None) AddClothingItem(Settings.settings.legsOuterOuter.ToString(), Settings.settings.legsOuterOuterCondition);
                if (Settings.settings.legsInnerInner != LegsInner.None) AddClothingItem(Settings.settings.legsInnerInner.ToString(), Settings.settings.legsInnerInnerCondition);
                if (Settings.settings.legsInnerOuter != LegsInner.None) AddClothingItem(Settings.settings.legsInnerOuter.ToString(), Settings.settings.legsInnerOuterCondition);
                if (Settings.settings.feetInnerInner != FeetInner.None) AddClothingItem(Settings.settings.feetInnerInner.ToString(), Settings.settings.feetInnerInnerCondition);
                if (Settings.settings.feetInnerOuter != FeetInner.None) AddClothingItem(Settings.settings.feetInnerOuter.ToString(), Settings.settings.feetInnerOuterCondition);
                if (Settings.settings.feetOuter != FeetOuter.None) AddClothingItem(Settings.settings.feetOuter.ToString(), Settings.settings.feetOuterCondition);

                // Fire Starting
                if (Settings.settings.firestarter != FireStarter.None)
                {
                    int qty = 1;
                    if (Settings.settings.firestarter == FireStarter.GEAR_PackMatches || Settings.settings.firestarter == FireStarter.GEAR_WoodMatches) qty = Settings.settings.matchQty;
                    GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.firestarter.ToString(), qty);
                }
                if (Settings.settings.tinderType != Tinder.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.tinderType.ToString(), Settings.settings.tinderQty);
                if (Settings.settings.fuelType != Fuel.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.fuelType.ToString(), Settings.settings.fuelQty);
                if (Settings.settings.accelerant) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Accelerant");

                // First Aid
                if (Settings.settings.antibiotics != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_BottleAntibiotics", Settings.settings.antibiotics);
                if (Settings.settings.antiseptic != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_BottleHydrogenPeroxide", Settings.settings.antiseptic);
                if (Settings.settings.bandages != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_HeavyBandage", Settings.settings.bandages);
                if (Settings.settings.emergencyStim != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_EmergencyStim", Settings.settings.emergencyStim);
                if (Settings.settings.oldMansBeardDressing != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_OldMansBeardDressing", Settings.settings.oldMansBeardDressing);
                if (Settings.settings.painkillers != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_BottlePainKillers", Settings.settings.painkillers);
                if (Settings.settings.preparedBirchBark != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_BirchbarkPrepared", Settings.settings.preparedBirchBark);
                if (Settings.settings.preparedReshiMushrooms != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_ReishiPrepared", Settings.settings.preparedReshiMushrooms);
                if (Settings.settings.preparedRoseHips != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_RosehipsPrepared", Settings.settings.preparedRoseHips);
                if (Settings.settings.waterPurificationTablets != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_WaterPurificationTablets", Settings.settings.waterPurificationTablets);

                // Food and Drink
                if (Settings.settings.food1 != Food.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.food1.ToString());
                if (Settings.settings.food2 != Food.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.food2.ToString());
                if (Settings.settings.drink1 != Drink.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.drink1.ToString());
                if (Settings.settings.drink2 != Drink.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.drink2.ToString());

                // Tools
                if (Settings.settings.bedroll != Bedroll.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.bedroll.ToString());
                if (Settings.settings.canOpener) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_CanOpener");
                if (Settings.settings.cooking != Cooking.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.cooking.ToString());
                if (Settings.settings.fishingTackle != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_HookAndLine", Settings.settings.fishingTackle);
                if (Settings.settings.hacksaw) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Hacksaw");
                if (Settings.settings.hatchet != Hatchet.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.hatchet.ToString());
                if (Settings.settings.heavyHammer) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Hammer");
                if (Settings.settings.knife != Knife.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.knife.ToString());
                if (Settings.settings.lightSource != LightSources.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.lightSource.ToString());
                if (Settings.settings.mountaineeringRope) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Rope");
                if (Settings.settings.prybar) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Prybar");
                if (Settings.settings.rifleCleaningKit) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_RifleCleaningKit");
                if (Settings.settings.sewingKit) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_SewingKit");
                if (Settings.settings.snare) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Snare");
                if (Settings.settings.sprayPaint) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_SprayPaintCan");
                if (Settings.settings.toolBox != ToolBox.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.toolBox.ToString());
                if (Settings.settings.weapon != Weapons.None) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(Settings.settings.weapon.ToString());
                if (Settings.settings.ammunitionQty != 0)
                {
                    switch (Settings.settings.weapon)
                    {
                        case Weapons.None:
                            break;
                        case Weapons.GEAR_FlareGun:
                            GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_FlareGunAmmoSingle", Settings.settings.ammunitionQty);
                            break;
                        case Weapons.GEAR_Rifle:
                            GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_RifleAmmoSingle", Settings.settings.ammunitionQty);
                            break;
                        case Weapons.GEAR_Revolver:
                            GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_RevolverAmmoSingle", Settings.settings.ammunitionQty);
                            break;
                        case Weapons.GEAR_Bow:
                            GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Arrow", Settings.settings.ammunitionQty);
                            break;
                    }
                }
                if (Settings.settings.whetstone) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_SharpeningStone");

                // Materials
                if (Settings.settings.arrowhead != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_ArrowHead", Settings.settings.arrowhead);
                if (Settings.settings.arrowShaft != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_ArrowShaft", Settings.settings.arrowShaft);
                if (Settings.settings.bullet != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Bullet", Settings.settings.bullet);
                if (Settings.settings.gunpowder != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_GunpowderCan", Settings.settings.gunpowder);
                if (Settings.settings.charcoal != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Charcoal", Settings.settings.charcoal);
                if (Settings.settings.crowFeather != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_CrowFeather", Settings.settings.crowFeather);
                if (Settings.settings.dustingSulfur != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_DustingSulfur", Settings.settings.dustingSulfur);
                if (Settings.settings.revolverShell != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_RevolverAmmoCasing", Settings.settings.revolverShell);
                if (Settings.settings.rifleShell != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_RifleAmmoCasing", Settings.settings.rifleShell);
                if (Settings.settings.scrapLead != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_ScrapLead", Settings.settings.scrapLead);
                if (Settings.settings.stumpRemover != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_StumpRemover", Settings.settings.stumpRemover);

                if (Settings.settings.bearHideCured != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_BearHideDried", Settings.settings.bearHideCured);
                if (Settings.settings.bearHideFresh != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_BearHide", Settings.settings.bearHideFresh);
                if (Settings.settings.deerHideCured != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_LeatherHideDried", Settings.settings.deerHideCured);
                if (Settings.settings.deerHideFresh != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_LeatherHide", Settings.settings.deerHideFresh);
                if (Settings.settings.gutCured != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_GutDried", Settings.settings.gutCured);
                if (Settings.settings.gutFresh != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Gut", Settings.settings.gutFresh);
                if (Settings.settings.mooseHideCured != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_MooseHideDried", Settings.settings.mooseHideCured);
                if (Settings.settings.mooseHideFresh != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_MooseHide", Settings.settings.mooseHideFresh);
                if (Settings.settings.rabbitPeltCured != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_RabbitPeltDried", Settings.settings.rabbitPeltCured);
                if (Settings.settings.rabbitPeltFresh != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_RabbitPelt", Settings.settings.rabbitPeltFresh);
                if (Settings.settings.wolfPeltCured != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_WolfPeltDried", Settings.settings.wolfPeltCured);
                if (Settings.settings.wolfPeltFresh != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_WolfPelt", Settings.settings.wolfPeltFresh);

                if (Settings.settings.birchSaplingCured != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_BirchSaplingDried", Settings.settings.birchSaplingCured);
                if (Settings.settings.birchSaplingFresh != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_BirchSapling", Settings.settings.birchSaplingFresh);
                if (Settings.settings.mapleSaplingCured != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_MapleSaplingDried", Settings.settings.mapleSaplingCured);
                if (Settings.settings.mapleSaplingFresh != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_MapleSapling", Settings.settings.mapleSaplingFresh);

                if (Settings.settings.cloth != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_Cloth", Settings.settings.cloth);
                if (Settings.settings.curedLeather != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_LeatherDried", Settings.settings.curedLeather);
                if (Settings.settings.scrapMetal != 0) GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory("GEAR_ScrapMetal", Settings.settings.scrapMetal);
            }
        }

        public static void AddClothingItem(string clothingItemName, float condition) 
        {
            GearItem newClothingItem = GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventoryWithCondition(clothingItemName, 1, condition);
            newClothingItem.m_ClothingItem.PutOn(ClothingLayer.NumLayers);
        }
    }
}

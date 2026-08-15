# **Action RPG — Core Design Doc**

## **Genre Clarification**

Real-time combat \+ respawn/checkpoints \+ hand-designed levels \= **action RPG dungeon crawler**, not a traditional roguelike (which typically pairs permadeath with procedural generation). That's fine — this is closer to Zelda-style dungeons or Souls-style checkpoint combat than Rogue/NetHack. Worth keeping in mind when looking at reference material or tutorials, since "roguelike" tutorials will often assume turn-based \+ procedural \+ permadeath.

## **Core Loop**

**Explore → Fight → Loot → Level Up → Explore deeper**

The player explores an open world with scattered dungeons, fights enemies for loot and experience, completes quests, clears dungeons, and grows stronger through gear and skills — repeating at increasing difficulty/depth.

## **Confirmed Pillars**

* **Movement/Combat:** Real-time — ranged and melee, dodge, block, parry/riposte  
* **Death:** Respawn / checkpoint system, Dark Souls-style — set checkpoints/bonfires, enemies respawn on death but player keeps gear and levels  
* **Levels:** Hand-designed (not procedurally generated)  
* **Progression:** Levels/stats, loot rarity tiers, skill tree  
* **World structure:** Open world with scattered dungeons, plus safe area/hub zones  
* **Enemy variety:** Standard mobs/pawns, plus bosses  
* **Win condition:** Boss slain

  ## **Minimum Playable Slice**

The first buildable, testable version of the game:

* Start in a safe hub area  
* One quest to follow  
* One overworld area/biome to explore  
* 3 basic loot chests scattered in the overworld  
* One dungeon to find and enter  
* 2 checkpoints inside the dungeon  
* One rare loot chest in the dungeon, post-boss  
* One boss fight at the end of the dungeon  
* Boss drops a legendary item  
* Enemies grant experience on defeat

This slice is the first real milestone — not the whole game. Get this feeling fun before adding anything beyond it.

## **Notes / Risks to Watch**

* **Open world \+ hand-designed** is more work than a single linear level. For the first slice, keep the overworld small and tight — just enough space to connect the hub, the 3 chests, and the dungeon entrance. Resist the urge to make it sprawling before the core loop is proven fun.  
* **Skill tree** is a separate system (data \+ UI) from core combat feel. Reasonable to treat as a stretch goal after the slice above is playable, so it doesn't block testing whether combat itself feels good.  
* **Parry/riposte** is one of the harder mechanics to get feeling right in real-time combat — timing windows, animation, feedback. Expect iteration. Don't let it block finishing the rest of the slice; a placeholder block/dodge is fine short-term.  
* 



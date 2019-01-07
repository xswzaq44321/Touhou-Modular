local radiate

radiate = function(boss)
	if (boss.delay > 3) then
		if (boss.delay > 3.5) then
			boss.delay = 0
			boss.a = 0
		end
		boss.a = boss.a + 0.5
		boss.radiate("pink_load", "pink_circle_small", 1, 4.4, boss.a * 11, 2 - boss.a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 5.0, boss.a * 11, 2 - boss.a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 5.6, boss.a * 11, 2 - boss.a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 6.2, boss.a * 11, 2 - boss.a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 4.4, -boss.a * 11, 2 - boss.a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 5.0, -boss.a * 11, 2 - boss.a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 5.6, -boss.a * 11, 2 - boss.a * 0.01)
		boss.radiate("pink_load", "pink_circle_small", 1, 6.2, -boss.a * 11, 2 - boss.a * 0.01)

		if (boss.a < 50) then
			boss.radiate("cyan_load", "cyan_seed", 1, 1.4, boss.a * 11 + 180, 1.5 - boss.a * 0.02)
			boss.radiate("cyan_load", "cyan_seed", 1, 2.0, boss.a * 11 + 180, 1.5 - boss.a * 0.02)
			boss.radiate("cyan_load", "cyan_seed", 1, 2.6, boss.a * 11 + 180, 1.5 - boss.a * 0.02)
			boss.radiate("cyan_load", "cyan_seed", 1, 3.2, boss.a * 11 + 180, 1.5 - boss.a * 0.02)
			boss.radiate("cyan_load", "cyan_seed", 1, 1.4, -boss.a * 11 + 180, 1.5 - boss.a * 0.02)
			boss.radiate("cyan_load", "cyan_seed", 1, 2.0, -boss.a * 11 + 180, 1.5 - boss.a * 0.02)
			boss.radiate("cyan_load", "cyan_seed", 1, 2.6, -boss.a * 11 + 180, 1.5 - boss.a * 0.02)
			boss.radiate("cyan_load", "cyan_seed", 1, 3.2, -boss.a * 11 + 180, 1.5 - boss.a * 0.02)
		end
	end
end

-- minions[1].upDate = function(tab)
-- 	radiate(tab)
-- end

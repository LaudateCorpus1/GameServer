using GameServerCore.Enums;
using static LeagueSandbox.GameServer.API.ApiFunctionManager;
using GameServerCore.Domain.GameObjects;
using LeagueSandbox.GameServer.GameObjects.Stats;
using LeagueSandbox.GameServer.Scripting.CSharp;
using GameServerCore.Domain.GameObjects.Spell;

namespace Highlander
{
    internal class Highlander : IBuffGameScript
    {
        public BuffType BuffType => BuffType.COMBAT_ENCHANCER;
        public BuffAddType BuffAddType => BuffAddType.REPLACE_EXISTING;
        public int MaxStacks => 1;
        public bool IsHidden => false;

        public IStatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(IAttackableUnit unit, IBuff buff, ISpell ownerSpell)
        {
            StatsModifier.MoveSpeed.PercentBonus = StatsModifier.MoveSpeed.PercentBonus + (15f + ownerSpell.Level * 10) / 100f;
            StatsModifier.AttackSpeed.PercentBonus = StatsModifier.AttackSpeed.PercentBonus + (5f + ownerSpell.Level * 25) / 100f;
            unit.AddStatModifier(StatsModifier);
            // TODO: add immunity to slows
        }

        public void OnDeactivate(IAttackableUnit unit, IBuff buff, ISpell ownerSpell)
        {
        }

        private void OnAutoAttack(IAttackableUnit target, bool isCrit)
        {
        }

        public void OnUpdate(float diff)
        {
        }
    }
}

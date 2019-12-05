//using System;
//using System.Collections.Generic;
//using System.Text;
//using SabberStoneCore.Model.Entities;

//namespace SabberStoneCore.Enchants
//{
//	public abstract class AbstractEffect
//	{
//		public virtual void ApplyTo(Playable playable)
//		{
//			throw new NotImplementedException();
//		}
//		public virtual void RemoveFrom(Playable playable)
//		{
//			throw new NotImplementedException();
//		}
//		public virtual void ApplyTo(Character character)
//		{
//			throw new NotImplementedException();
//		}
//		public virtual void RemoveFrom(Character character)
//		{
//			throw new NotImplementedException();
//		}
//		public virtual void ApplyTo(HeroInPlay hero)
//		{
//			throw new NotImplementedException();
//		}
//		public virtual void RemoveFrom(HeroInPlay hero)
//		{
//			throw new NotImplementedException();
//		}
//		public virtual void ApplyTo(MinionInPlay minion)
//		{
//			throw new NotImplementedException();
//		}
//		public virtual void RemoveFrom(MinionInPlay minion)
//		{
//			throw new NotImplementedException();
//		}
//		//internal static AbstractEffect IEffectToAbstract<T>(GenericEffect<T> eff) where T: Playable
//		//{
//		//	switch (eff._attr)
//		//	{
//		//		case ATK atk:
//		//			switch (eff._operator)
//		//			{
//		//				case EffectOperator.ADD:
//		//					return Attribte
//		//					break;
//		//				case EffectOperator.SUB:
//		//					break;
//		//				case EffectOperator.MUL:
//		//					break;
//		//				case EffectOperator.SET:
//		//					break;
//		//				default:
//		//					throw new ArgumentOutOfRangeException();
//		//			}
//		//			break;
//		//	}
//		//}
//	}

//	public class AttributeAddEffect : AbstractEffect
//	{
//		public readonly int Attribute;
//		public readonly int Value;

//		public AttributeAddEffect(Attributes attr, int value)
//		{
//			Attribute = (int) attr;
//			Value = value;
//		}

//		public override void ApplyTo(Character playable)
//		{
//			playable.GetIntRef(Attribute) += Value;
//		}

//		public override void RemoveFrom(Character playable)
//		{
//			playable.GetIntRef(Attribute) -= Value;
//		}
//	}

//	public class AttributeAddAuraEffect : AbstractEffect
//	{
//		private readonly int Attribute;
//		private readonly int Value;
//		public AttributeAddAuraEffect(Attributes attr, int value)
//		{
//			Attribute = (int) attr;
//			Value = value;
//		}
//	}

//	public class AttributeSetEffect : AbstractEffect
//	{
//		private readonly int _attribute;
//		private readonly int _value;
//		public AttributeSetEffect(Attributes attr, int value)
//		{
//			_attribute = (int) attr;
//			_value = value;
//		}
//		public override void ApplyTo(Character playable)
//		{
//			playable.GetIntRef(_attribute) = _value;
//		}
//	}

//	public class BooleanAttributeEffect : AbstractEffect
//	{
//		private readonly int _attribute;
//		private readonly bool _value;
//		private readonly Action<Character> _afterApplyTask;
//	}
//}

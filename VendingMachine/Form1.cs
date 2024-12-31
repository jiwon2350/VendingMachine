using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachine
{
    public partial class Form1 : Form
    {
        private Player player; // 전역 플레이어 
        private Monster Goblin; // 전역 몬스터 
        private Monster Slime;//전역 슬라임


        public Form1()
        {
            InitializeComponent();

            // 플레이어와 몬스터 초기화
            this.player = new Player { Name = "Hero", Health = 300, AttackPower = 18 };
            this.Goblin = new Monster { Name = "Goblin", Health = 100, AttackPower = 33 };
            this.Slime = new Monster { Name = "Slime", Health = 200, AttackPower = 27 };        
        }

        private void SimulateBattle()
        {
            // 전투 시작 메시지
            MessageBox.Show("전투 시작!");

            // 전투 루프
            while (player.Health > 0 && Goblin.Health > 0)
            {
                // 플레이어가 몬스터 선공
                player.Attack(Goblin);
                textBox_MonsterHP.Text += "남은 HP = " + Goblin.Health.ToString()+ "\r\n";
                Goblin.Attack(player);
                textBox_PlayerHP.Text += "남은 HP = " + player.Health.ToString()+ "\r\n";
                // 몬스터의 2번째 공격은 분노 공격
                player.Attack(Goblin);
                textBox_MonsterHP.Text += "남은 HP = " + Goblin.Health.ToString() + "\r\n";
                Goblin.RageAttack(player);
                textBox_PlayerHP.Text += "남은 HP = " + player.Health.ToString() + "\r\n";


            }

            // 전투 종료 메시지
            if (player.Health > 0 && Goblin.Health <= 0)
            {
                MessageBox.Show("플레이어가 승리했습니다!");
            }
            else if (Goblin.Health > 0 && player.Health <= 0)
            {
                MessageBox.Show("몬스터가 승리했습니다!");
            }
            else
            {
                MessageBox.Show("둘 다 살아남았습니다. 무승부입니다.");
            }
        }

        private void button_fight_Click(object sender, EventArgs e)
        {
            // 전투시작 버튼 
            SimulateBattle();
        }
        

    }

    // 캐릭터 기본 클래스
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }

        public abstract void Attack(Character target);

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            MessageBox.Show($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력: {Health}");
        }
    }

    // 플레이어 클래스
    public class Player : Character
    {
        public override void Attack(Character target)
        {
            MessageBox.Show($"{Name}이(가) {target.Name}을(를) 공격했습니다!");
            target.TakeDamage(AttackPower);
        }
    }

    // 몬스터 클래스
    public class Monster : Character
    {
        public override void Attack(Character target)
        {
            MessageBox.Show($"{Name}이(가) {target.Name}을(를) 공격했습니다!");
            target.TakeDamage(AttackPower);
        }

        // 분노 공격 메서드
        public void RageAttack(Character target)
        {
            int rageDamage = AttackPower * 3; // rage 모드에서의 공격력 3배 
            target.TakeDamage(rageDamage);
            MessageBox.Show($"{Name}이(가) 분노 공격으로 {target.Name}에게 {rageDamage} 데미지를 입혔습니다!");
        }
    }

}

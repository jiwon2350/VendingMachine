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

        private void HP_Input_btn_Click(object sender, EventArgs e)
        {
            // textBox_HP에서 입력값 가져오기
            string input = HP_Input.Text;

            // 입력값이 유효한 정수인지 확인
            if (int.TryParse(input, out int hpValue))
            {
                // 플레이어의 HP 증가
                player.LevelUp(hpValue);

                // 텍스트 박스 초기화
                HP_Input.Clear();
            }
            else
            {
                MessageBox.Show("유효한 숫자를 입력해주세요!");
            }
        }

        

        private void Attack_Point_btn_Click(object sender, EventArgs e)
        {
            // textBox_AttackPower에서 입력값 가져오기
            string inputHP = HP_Input.Text; // HP 값
            string inputAP = AttackPoint_Input.Text; // 공격력 값

            // 입력값이 유효한지 확인
            if (int.TryParse(inputHP, out int hpValue) && int.TryParse(inputAP, out int apValue))
            {
                // 플레이어의 HP와 AttackPower 증가
                player.LevelUp(hpValue, apValue);

                // 텍스트 박스 초기화
                HP_Input.Clear();
                AttackPoint_Input.Clear();
            }
            else
            {
                MessageBox.Show("유효한 숫자를 입력해주세요!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    // 캐릭터 기본 클래스
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }

        public abstract void Attack(Character target);

        public virtual void Talk()
        {
            MessageBox.Show($"{Name}가 말을 합니다 !");
        }

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
        public override void Talk()
        {
            MessageBox.Show("캐릭터가 결의를 외칩니다 ");
        }
        
        public void LevelUp(int hp)//hp 설정해주기
        {
            Health += hp;
            MessageBox.Show($"HP가 {hp}만큼 증가하여 {Health}가 되었습니다");
        }

        public void LevelUp(int hp, int power)// 둘다 설정해주기 
        {
            Health += hp;
            AttackPower += power;
            MessageBox.Show($"HP가 {hp}, 공격력이 {power}만큼 증가하여 HP: {Health}, 공격력: {AttackPower}이(가) 되었습니다.");
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

        public override void Talk()
        {
            MessageBox.Show("몬스터가 캐릭터를 공격 했습니다 !");
        }
    }

}

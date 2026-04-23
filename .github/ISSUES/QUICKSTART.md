# Quick Start: Creating DDD Transition Issues

## 🚀 Fastest Way (1 command)

```bash
cd .github/ISSUES
bash create-issues.sh
```

This creates all 20 issues automatically with proper labels and formatting.

## 📋 What You'll Get

After running the script, you'll have 20 GitHub issues created:

### Phase 1: Foundation (5 issues)
1. ✅ Setup DDD Project Structure
2. ✅ Create Value Objects for User Bounded Context  
3. ✅ Create User Aggregate Root
4. ✅ Create Visit Aggregate Root
5. ✅ Define Repository Interfaces in Domain

### Phase 2: CQRS (3 issues)
6. ✅ Implement CQRS Pattern - Commands
7. ✅ Implement CQRS Pattern - Queries
8. ✅ Implement Unit of Work Pattern

### Phase 3: Infrastructure (4 issues)
9. ✅ Implement Repository Concrete Classes
10. ✅ Implement Domain Event Handlers
12. ✅ Implement Password Hashing Service (DIP)
13. ✅ Implement Authentication Service (SRP & DIP)

### Phase 4: API Layer (3 issues)
11. ✅ Refactor API Controllers to Use CQRS
14. ✅ Add Validation Pipeline (OCP)
15. ✅ Implement Logging and Monitoring

### Phase 5: Polish (5 issues)
16. ✅ Add Pagination and Filtering (LSP)
17. ✅ Implement Integration Events
18. ✅ Create Migration Script
19. ✅ Update API Documentation
20. ✅ Performance Testing and Optimization

## 🏷️ Labels That Will Be Applied

Each issue gets appropriate labels:
- **Phase**: Phase-1 through Phase-6
- **Priority**: priority-high, priority-medium, priority-low
- **Type**: domain, application, infrastructure, api, architecture, security, testing, documentation
- **Project**: DDD-transition

## 🔧 Prerequisites

Before running the script:

1. **Install GitHub CLI** (if not already installed):
   ```bash
   # On macOS
   brew install gh
   
   # On Linux
   curl -fsSL https://cli.github.com/packages/githubcli-archive-keyring.gpg | sudo dd of=/usr/share/keyrings/githubcli-archive-keyring.gpg
   ```

2. **Authenticate with GitHub**:
   ```bash
   gh auth login
   ```

3. **Verify you're in the right repository**:
   ```bash
   gh repo view
   ```

## 📝 Manual Creation (Alternative)

If you prefer to create issues manually or one at a time:

### Via GitHub CLI:
```bash
gh issue create \
  --title "Task 1: Setup DDD Project Structure" \
  --body-file task-01-setup-ddd-structure.md \
  --label "DDD-transition,Phase-1,priority-high,architecture"
```

### Via GitHub Web UI:
1. Go to repository → Issues → New Issue
2. Open a task file (e.g., `task-01-setup-ddd-structure.md`)
3. Copy the content (skip the YAML frontmatter at top)
4. Paste into issue description
5. Add the labels shown in the frontmatter
6. Create issue

## 🎯 After Creating Issues

1. **View all transition issues**:
   ```bash
   gh issue list --label DDD-transition
   ```

2. **Create a Project Board**:
   ```bash
   gh project create --title "DDD Transition" --body "Track progress of DDD architecture transition"
   ```

3. **Assign issues** to team members or agents

4. **Start with Phase 1** - tasks 1 through 5

## 📊 Track Progress

Monitor your progress:
```bash
# View open issues by phase
gh issue list --label Phase-1 --state open

# View all completed issues
gh issue list --label DDD-transition --state closed

# View high priority issues
gh issue list --label priority-high --state open
```

## ⚠️ Important Notes

- Tasks have **dependencies** - check each issue's "Dependencies" section
- Start with **Phase 1** tasks before moving to later phases
- **High priority** tasks must be completed for basic functionality
- Each task includes **acceptance criteria** - use them for verification
- **Code examples** are provided in implementation notes

## 🆘 Troubleshooting

**Script fails with "403 Forbidden":**
- Run `gh auth status` to check authentication
- Run `gh auth refresh` to refresh credentials
- Ensure you have write access to the repository

**Script fails with "Not found":**
- Verify you're in the correct repository
- Check you have permissions to create issues

**Want to create only specific issues:**
- Edit the `create-issues.sh` script
- Comment out tasks you don't want to create
- Or use manual creation method for specific tasks

## 📚 Additional Resources

- **Full documentation**: See `README.md` in this directory
- **Task overview**: See `SUMMARY.md` for dependency graph and timeline
- **Architecture details**: See `/architecture.md` in repository root

---

**Ready?** Run `bash create-issues.sh` now! 🚀

//
//  _MDPAchievementModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPAchievementModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPAchievementModelAttributes {
	__unsafe_unretained NSString *achievedDate;
	__unsafe_unretained NSString *achievementType;
	__unsafe_unretained NSString *idAchievement;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *imageUrl;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *level;
} MDPAchievementModelAttributes;

extern const struct MDPAchievementModelRelationships {
	__unsafe_unretained NSString *descriptionAchievement;
	__unsafe_unretained NSString *levelName;
	__unsafe_unretained NSString *pagedAchievementsResults;
} MDPAchievementModelRelationships;

@class MDPLocaleDescriptionModel;
@class MDPLocaleDescriptionModel;
@class MDPPagedAchievementsModel;

@interface _MDPAchievementModel : NSManagedObject

@property (nonatomic, strong) NSDate* achievedDate;

//- (BOOL)validateAchievedDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* achievementType;

//- (BOOL)validateAchievementType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idAchievement;

//- (BOOL)validateIdAchievement:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* imageUrl;

//- (BOOL)validateImageUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* level;

@property (atomic) int64_t levelValue;
- (int64_t)levelValue;
- (void)setLevelValue:(int64_t)value_;

//- (BOOL)validateLevel:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *descriptionAchievement;

- (NSMutableSet*)descriptionAchievementSet;

@property (nonatomic, strong) NSSet *levelName;

- (NSMutableSet*)levelNameSet;

@property (nonatomic, strong) NSSet *pagedAchievementsResults;

- (NSMutableSet*)pagedAchievementsResultsSet;

@end

@interface _MDPAchievementModel (DescriptionAchievementCoreDataGeneratedAccessors)
- (void)addDescriptionAchievement:(NSSet*)value_;
- (void)removeDescriptionAchievement:(NSSet*)value_;
- (void)addDescriptionAchievementObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeDescriptionAchievementObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPAchievementModel (LevelNameCoreDataGeneratedAccessors)
- (void)addLevelName:(NSSet*)value_;
- (void)removeLevelName:(NSSet*)value_;
- (void)addLevelNameObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeLevelNameObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPAchievementModel (PagedAchievementsResultsCoreDataGeneratedAccessors)
- (void)addPagedAchievementsResults:(NSSet*)value_;
- (void)removePagedAchievementsResults:(NSSet*)value_;
- (void)addPagedAchievementsResultsObject:(MDPPagedAchievementsModel*)value_;
- (void)removePagedAchievementsResultsObject:(MDPPagedAchievementsModel*)value_;
@end

@interface _MDPAchievementModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveAchievedDate;
- (void)setPrimitiveAchievedDate:(NSDate*)value;

- (NSString*)primitiveAchievementType;
- (void)setPrimitiveAchievementType:(NSString*)value;

- (NSString*)primitiveIdAchievement;
- (void)setPrimitiveIdAchievement:(NSString*)value;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSString*)primitiveImageUrl;
- (void)setPrimitiveImageUrl:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveLevel;
- (void)setPrimitiveLevel:(NSNumber*)value;

- (int64_t)primitiveLevelValue;
- (void)setPrimitiveLevelValue:(int64_t)value_;

- (NSMutableSet*)primitiveDescriptionAchievement;
- (void)setPrimitiveDescriptionAchievement:(NSMutableSet*)value;

- (NSMutableSet*)primitiveLevelName;
- (void)setPrimitiveLevelName:(NSMutableSet*)value;

- (NSMutableSet*)primitivePagedAchievementsResults;
- (void)setPrimitivePagedAchievementsResults:(NSMutableSet*)value;

@end

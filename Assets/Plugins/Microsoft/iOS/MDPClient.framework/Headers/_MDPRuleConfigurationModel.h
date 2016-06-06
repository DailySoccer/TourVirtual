//
//  _MDPRuleConfigurationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPRuleConfigurationModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPRuleConfigurationModelAttributes {
	__unsafe_unretained NSString *execsCount;
	__unsafe_unretained NSString *idAction;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *prefixMode;
} MDPRuleConfigurationModelAttributes;

extern const struct MDPRuleConfigurationModelRelationships {
	__unsafe_unretained NSString *achievementConfigurationRules;
} MDPRuleConfigurationModelRelationships;

@class MDPAchievementConfigurationModel;

@interface _MDPRuleConfigurationModel : NSManagedObject

@property (nonatomic, strong) NSNumber* execsCount;

@property (atomic) int64_t execsCountValue;
- (int64_t)execsCountValue;
- (void)setExecsCountValue:(int64_t)value_;

//- (BOOL)validateExecsCount:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idAction;

//- (BOOL)validateIdAction:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* prefixMode;

@property (atomic) BOOL prefixModeValue;
- (BOOL)prefixModeValue;
- (void)setPrefixModeValue:(BOOL)value_;

//- (BOOL)validatePrefixMode:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPAchievementConfigurationModel *achievementConfigurationRules;

//- (BOOL)validateAchievementConfigurationRules:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPRuleConfigurationModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveExecsCount;
- (void)setPrimitiveExecsCount:(NSNumber*)value;

- (int64_t)primitiveExecsCountValue;
- (void)setPrimitiveExecsCountValue:(int64_t)value_;

- (NSString*)primitiveIdAction;
- (void)setPrimitiveIdAction:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitivePrefixMode;
- (void)setPrimitivePrefixMode:(NSNumber*)value;

- (BOOL)primitivePrefixModeValue;
- (void)setPrimitivePrefixModeValue:(BOOL)value_;

- (MDPAchievementConfigurationModel*)primitiveAchievementConfigurationRules;
- (void)setPrimitiveAchievementConfigurationRules:(MDPAchievementConfigurationModel*)value;

@end

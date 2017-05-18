//
//  _MDPAchievementConfigurationTypeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPAchievementConfigurationTypeModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPAchievementConfigurationTypeModelAttributes {
	__unsafe_unretained NSString *idType;
	__unsafe_unretained NSString *language;
	__unsafe_unretained NSString *lastUpdateAt;
} MDPAchievementConfigurationTypeModelAttributes;

extern const struct MDPAchievementConfigurationTypeModelRelationships {
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *pagedAchievementConfigurationType;
} MDPAchievementConfigurationTypeModelRelationships;

@class MDPLocaleDescriptionModel;
@class MDPPagedAchievementConfigurationTypeModel;

@interface _MDPAchievementConfigurationTypeModel : NSManagedObject

@property (nonatomic, strong) NSString* idType;

//- (BOOL)validateIdType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* language;

//- (BOOL)validateLanguage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *name;

- (NSMutableSet*)nameSet;

@property (nonatomic, strong) NSSet *pagedAchievementConfigurationType;

- (NSMutableSet*)pagedAchievementConfigurationTypeSet;

@end

@interface _MDPAchievementConfigurationTypeModel (NameCoreDataGeneratedAccessors)
- (void)addName:(NSSet*)value_;
- (void)removeName:(NSSet*)value_;
- (void)addNameObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeNameObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPAchievementConfigurationTypeModel (PagedAchievementConfigurationTypeCoreDataGeneratedAccessors)
- (void)addPagedAchievementConfigurationType:(NSSet*)value_;
- (void)removePagedAchievementConfigurationType:(NSSet*)value_;
- (void)addPagedAchievementConfigurationTypeObject:(MDPPagedAchievementConfigurationTypeModel*)value_;
- (void)removePagedAchievementConfigurationTypeObject:(MDPPagedAchievementConfigurationTypeModel*)value_;
@end

@interface _MDPAchievementConfigurationTypeModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdType;
- (void)setPrimitiveIdType:(NSString*)value;

- (NSString*)primitiveLanguage;
- (void)setPrimitiveLanguage:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSMutableSet*)primitiveName;
- (void)setPrimitiveName:(NSMutableSet*)value;

- (NSMutableSet*)primitivePagedAchievementConfigurationType;
- (void)setPrimitivePagedAchievementConfigurationType:(NSMutableSet*)value;

@end

//
//  _MDPIndexedGroupModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPIndexedGroupModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPIndexedGroupModelAttributes {
	__unsafe_unretained NSString *avatarUrl;
	__unsafe_unretained NSString *country;
	__unsafe_unretained NSString *groupType;
	__unsafe_unretained NSString *idIndexedGroup;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
} MDPIndexedGroupModelAttributes;

extern const struct MDPIndexedGroupModelRelationships {
	__unsafe_unretained NSString *pagedIndexedGroupsResults;
} MDPIndexedGroupModelRelationships;

@class MDPPagedIndexedGroupsModel;

@interface _MDPIndexedGroupModel : NSManagedObject

@property (nonatomic, strong) NSString* avatarUrl;

//- (BOOL)validateAvatarUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* country;

//- (BOOL)validateCountry:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* groupType;

@property (atomic) uint16_t groupTypeValue;
- (uint16_t)groupTypeValue;
- (void)setGroupTypeValue:(uint16_t)value_;

//- (BOOL)validateGroupType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idIndexedGroup;

//- (BOOL)validateIdIndexedGroup:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPagedIndexedGroupsModel *pagedIndexedGroupsResults;

//- (BOOL)validatePagedIndexedGroupsResults:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPIndexedGroupModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAvatarUrl;
- (void)setPrimitiveAvatarUrl:(NSString*)value;

- (NSString*)primitiveCountry;
- (void)setPrimitiveCountry:(NSString*)value;

- (NSNumber*)primitiveGroupType;
- (void)setPrimitiveGroupType:(NSNumber*)value;

- (uint16_t)primitiveGroupTypeValue;
- (void)setPrimitiveGroupTypeValue:(uint16_t)value_;

- (NSString*)primitiveIdIndexedGroup;
- (void)setPrimitiveIdIndexedGroup:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (MDPPagedIndexedGroupsModel*)primitivePagedIndexedGroupsResults;
- (void)setPrimitivePagedIndexedGroupsResults:(MDPPagedIndexedGroupsModel*)value;

@end

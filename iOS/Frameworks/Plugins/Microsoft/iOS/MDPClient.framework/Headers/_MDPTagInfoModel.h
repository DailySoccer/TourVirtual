//
//  _MDPTagInfoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPTagInfoModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPTagInfoModelAttributes {
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *tag;
} MDPTagInfoModelAttributes;

extern const struct MDPTagInfoModelRelationships {
	__unsafe_unretained NSString *name;
} MDPTagInfoModelRelationships;

@class MDPLocaleDescriptionModel;

@interface _MDPTagInfoModel : NSManagedObject

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* tag;

//- (BOOL)validateTag:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *name;

- (NSMutableSet*)nameSet;

@end

@interface _MDPTagInfoModel (NameCoreDataGeneratedAccessors)
- (void)addName:(NSSet*)value_;
- (void)removeName:(NSSet*)value_;
- (void)addNameObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeNameObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPTagInfoModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveTag;
- (void)setPrimitiveTag:(NSString*)value;

- (NSMutableSet*)primitiveName;
- (void)setPrimitiveName:(NSMutableSet*)value;

@end

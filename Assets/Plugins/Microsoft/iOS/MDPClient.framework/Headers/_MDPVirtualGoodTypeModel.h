//
//  _MDPVirtualGoodTypeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPVirtualGoodTypeModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPVirtualGoodTypeModelAttributes {
	__unsafe_unretained NSString *highLight;
	__unsafe_unretained NSString *idType;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *parentIdType;
} MDPVirtualGoodTypeModelAttributes;

extern const struct MDPVirtualGoodTypeModelRelationships {
	__unsafe_unretained NSString *descriptionVirtualGoodType;
	__unsafe_unretained NSString *pagedVirtualGoodTypeResults;
} MDPVirtualGoodTypeModelRelationships;

@class MDPLocaleDescriptionModel;
@class MDPPagedVirtualGoodTypeModel;

@interface _MDPVirtualGoodTypeModel : NSManagedObject

@property (nonatomic, strong) NSNumber* highLight;

@property (atomic) BOOL highLightValue;
- (BOOL)highLightValue;
- (void)setHighLightValue:(BOOL)value_;

//- (BOOL)validateHighLight:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idType;

//- (BOOL)validateIdType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* parentIdType;

//- (BOOL)validateParentIdType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *descriptionVirtualGoodType;

- (NSMutableSet*)descriptionVirtualGoodTypeSet;

@property (nonatomic, strong) NSSet *pagedVirtualGoodTypeResults;

- (NSMutableSet*)pagedVirtualGoodTypeResultsSet;

@end

@interface _MDPVirtualGoodTypeModel (DescriptionVirtualGoodTypeCoreDataGeneratedAccessors)
- (void)addDescriptionVirtualGoodType:(NSSet*)value_;
- (void)removeDescriptionVirtualGoodType:(NSSet*)value_;
- (void)addDescriptionVirtualGoodTypeObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeDescriptionVirtualGoodTypeObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPVirtualGoodTypeModel (PagedVirtualGoodTypeResultsCoreDataGeneratedAccessors)
- (void)addPagedVirtualGoodTypeResults:(NSSet*)value_;
- (void)removePagedVirtualGoodTypeResults:(NSSet*)value_;
- (void)addPagedVirtualGoodTypeResultsObject:(MDPPagedVirtualGoodTypeModel*)value_;
- (void)removePagedVirtualGoodTypeResultsObject:(MDPPagedVirtualGoodTypeModel*)value_;
@end

@interface _MDPVirtualGoodTypeModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveHighLight;
- (void)setPrimitiveHighLight:(NSNumber*)value;

- (BOOL)primitiveHighLightValue;
- (void)setPrimitiveHighLightValue:(BOOL)value_;

- (NSString*)primitiveIdType;
- (void)setPrimitiveIdType:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveParentIdType;
- (void)setPrimitiveParentIdType:(NSString*)value;

- (NSMutableSet*)primitiveDescriptionVirtualGoodType;
- (void)setPrimitiveDescriptionVirtualGoodType:(NSMutableSet*)value;

- (NSMutableSet*)primitivePagedVirtualGoodTypeResults;
- (void)setPrimitivePagedVirtualGoodTypeResults:(NSMutableSet*)value;

@end
